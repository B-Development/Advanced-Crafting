using AdvancedCrafting.Extentions;
using AdvancedCrafting.Other.Recipe;
using AdvancedCrafting.Other.Webhook;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Framework.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdvancedCrafting.Commands
{
    internal class CraftCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller
            => AllowedCaller.Player;

        public string Name
            => "craft";

        public string Help
            => "AdvancedCraft creates custom crafted items according to a recipe";

        public string Syntax
            => string.Empty;

        public List<string> Aliases
            => new List<string>();

        public List<string> Permissions
            => new List<string> { "craft" };

        private string Translate(string TranslationKey, params object[] Placeholders) =>
            Main.Instance.Translations.Instance.Translate(TranslationKey, Placeholders);

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = caller.Player();
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, Translate("specify-recipe"), Color.red);
                player.inventory.sendStorage();
                player.inventory.closeStorage();
                return;
            }

            var storage = GetInteractableStorage(caller);
            if (storage != null)
            {
                storage.isOpen = true;
                storage.opener = caller.Player();
                Main.Instance.Configuration.Instance.Recipes
                    .Where(recipe => recipe.NameOfRecipe.Equals(command[0], StringComparison.InvariantCultureIgnoreCase))
                    .ToList()
                    .ForEach(recipe => CraftItem(caller, storage, recipe.RewardItem, recipe.Ingredients, recipe.Permissions, recipe.Containers));

                player.inventory.isStoring = true;
                player.inventory.isStorageTrunk = false;
                player.inventory.storage = storage;
                player.inventory.updateItems(PlayerInventory.STORAGE, storage.items);
                player.inventory.sendStorage();
                player.inventory.closeStorage();
            }
        }

        private InteractableStorage GetInteractableStorage(IRocketPlayer caller)
        {
            // Looking at chest?
            var look = caller.Player().look;
            if (PhysicsUtility.raycast(new Ray(look.aim.position, look.aim.forward), out RaycastHit hit, Mathf.Infinity, RayMasks.BARRICADE_INTERACT))
            {
                // Find storage container in view
                var storage = hit.transform.GetComponent<InteractableStorage>();

                // If storage is found
                if (storage != null)
                {
                    return storage;
                }

                UnturnedChat.Say(caller, Translate("invalid_storage"), Color.red);
            }
            else
            {
                UnturnedChat.Say(caller, Translate("no_object"), Color.red);
            }

            return null;
        }

        private void CraftItem(IRocketPlayer caller, InteractableStorage storage, ushort rewardItem, IEnumerable<Ingredient> ingredients, IEnumerable<Permission> permissions, IEnumerable<Container> containers)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (permissions.Any())
            {
                if (!caller.GetPermissions().Select(p => p.Name).Intersect(permissions.Select(p => p.Value).ToList()).Any())
                {
                    Main.Instance.Configuration.Instance.Webhook.ForEach(webhook => WebhookFailConfig(webhook.FailColor, webhook.Enabled, webhook.Url, player, rewardItem));
                    UnturnedChat.Say(caller, Translate("no-perm-for-craft"), Color.red);
                    return;
                }
            }

            if (containers.Any())
            {
                if (!containers.Any(x => storage.name == x))
                {
                    UnturnedChat.Say(caller, Translate("invalid_storage_type"), Color.red);
                    return;
                }
            }

            var results = ingredients.Select(ingredient => new
            {
                ingredient.Item,
                ingredient.Amount,
                inventorySearches = storage.items.search(new List<InventorySearch>(), ingredient.Item, false, true)
            });
            if (!results.All(result => result.inventorySearches.Select(r => (int)r.jar.item.amount).Sum() >= result.Amount))
            {
                return;
            }
            results.ToList().ForEach(result =>
            {
                // Delete items
                var amountToDelete = result.Amount;

                result.inventorySearches.ForEach(inventorySearch =>
                {
                    if (amountToDelete > 0)
                    {
                        var index = storage.items.getIndex(inventorySearch.jar.x, inventorySearch.jar.y);
                        storage.items.removeItem(index);
                        player.Inventory.closeStorage();
                    }
                });
            });

            UpdateAndCloseStorage(player, storage);

            // Give reward.
            ((UnturnedPlayer)caller).GiveItem(rewardItem, 1);
            Main.Instance.Configuration.Instance.Webhook.ForEach(webhook => WebhookSuccessConfig(webhook.SuccessColor, webhook.Enabled, webhook.Url, player, rewardItem));

            UnturnedChat.Say(caller, Translate("successful-Craft"), Color.green);
        }


        private void WebhookFailConfig(string FailColor, bool enabled, string webhookUrl, UnturnedPlayer player, ushort rewardItem)
        {
            if (enabled)
            {
                FailCraft(player, webhookUrl, FailColor, rewardItem);
            }
        }

        private void WebhookSuccessConfig(string SuccessColor, bool enabled, string webhookUrl, UnturnedPlayer player, ushort rewardItem)
        {
            if (enabled)
            {
                SuccessCraft(player, webhookUrl, SuccessColor, rewardItem);
            }
        }

        private static void UpdateAndCloseStorage(UnturnedPlayer player, InteractableStorage storage)
        {
            player.Inventory.isStoring = true;
            player.Inventory.isStorageTrunk = false;
            player.Inventory.storage = storage;
            player.Inventory.updateItems(PlayerInventory.STORAGE, storage.items);
            player.Inventory.sendStorage();
            player.Inventory.closeStorage();
        }

        private static void FailCraft(UnturnedPlayer player, string Url, string FailColor, ushort rewardItem)
            => DiscordHelper.FailCraftWebhook(player, Url, FailColor, rewardItem);

        private static void SuccessCraft(UnturnedPlayer player, string Url, string SuccessColor, ushort rewardItem)
            => DiscordHelper.SuccessCraftWebhook(player, Url, SuccessColor, rewardItem);
    }
}
