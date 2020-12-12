using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using SDG.Framework.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using AdvancedCrating.Extentions;
using AdvancedCrating.Other;

namespace AdvancedCrating.Commands
{
    class Craft_Command : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "craft";

        public string Help => "AdvancedCraft creates custom crafted items according to a recipe";

        public string Syntax => string.Empty;

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "craft.storage" };

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
                Main.Instance.Configuration.Instance.Recipes.ForEach(recipe => CraftItem(recipe.NameOfRecipe, command, caller, storage, recipe.RewardItem, recipe.Ingredients, recipe.Permission));

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
            var look = caller.Player().look;
            if (PhysicsUtility.raycast(new Ray(look.aim.position, look.aim.forward), out RaycastHit hit, Mathf.Infinity, RayMasks.BARRICADE_INTERACT))
            {
                var storage = hit.transform.GetComponent<InteractableStorage>();
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

        private bool CraftItem(string nameOfRecipe, string[] command, IRocketPlayer caller, InteractableStorage storage, ushort rewardItem, IEnumerable<Ingredient> ingredients, string permission)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if(caller.HasPermission(permission))
            {
                if (command[0] != nameOfRecipe)
                {
                    return true;
                }
                else if (nameOfRecipe == command[0])
                {

                    var results = ingredients.Select(ingredient => new
                    {
                        ingredient.Item,
                        ingredient.Amount,
                        inventorySearches = storage.items.search(new List<InventorySearch>(), ingredient.Item, false, true)
                    });
                    if (!results.All(result => result.inventorySearches.Select(r => (int)r.jar.item.amount).Sum() >= result.Amount))
                    {
                        return false;
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
                    UnturnedChat.Say(caller, Translate("Successful-Craft"), Color.green);
                    return true;
                }
                return true;
            }
            return true;
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
    }
}
