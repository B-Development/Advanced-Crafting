using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Items;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections;
using UnityEngine;

namespace Replace_ammo
{
    public class Main : RocketPlugin<Config>
    {

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= OnPlayerConnected;
        }
        protected override void Load()
        {
            U.Events.OnPlayerConnected += OnPlayerConnected;
        }

        public override Rocket.API.Collections.TranslationList DefaultTranslations =>
            new Rocket.API.Collections.TranslationList
            {
            };
        private void OnPlayerConnected(UnturnedPlayer player)
        {
            player.Inventory.onInventoryAdded += OnInventoryAdded;
        }

        private void OnInventoryAdded(byte page, byte index, ItemJar jar)
        {
            Configuration.Instance.AmmoReplaces.ForEach(replace => Replace_Ammo(replace.Ammo, replace.Item, jar, index, page));   
        }

        private void Replace_Ammo(ushort ammo, ushort item, ItemJar jar, byte index, byte page)
        {
            var itemid = jar.item.id;
            if(itemid == item)
            {
                UnturnedChat.Say("test 1", Color.magenta);
            }
        }
    }
}
