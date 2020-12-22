using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Items;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections;
using UnityEngine;
using System.Linq;

namespace Replace_ammo
{
    public class Main : RocketPlugin<Config>
    {

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerInventoryUpdated -= OnPlayerInventoryUpdated;
        }
        protected override void Load()
        {
            UnturnedPlayerEvents.OnPlayerInventoryUpdated += OnPlayerInventoryUpdated;
        }

        private void OnPlayerInventoryUpdated(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex, ItemJar itemJar)
        {
            Configuration.Instance.AmmoReplaces
                .Where(ammoReplace => ammoReplace.Item == itemJar.item.id)
                .ToList()
                .ForEach(ammoReplace => Replace(ammoReplace.Ammo, ammoReplace.Item, player, itemJar, inventoryIndex));
        }

        private void Replace(ushort ammo, ushort item, UnturnedPlayer player, ItemJar itemJar, byte inventoryIndex)
        {
        }

        public override Rocket.API.Collections.TranslationList DefaultTranslations =>
            new Rocket.API.Collections.TranslationList
            {
            };
    }
}
