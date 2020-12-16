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

namespace Replace_ammo
{
    public class Main : RocketPlugin<Config>
    {

        protected override void Unload()
        {
        }
        protected override void Load()
        {
        }
        public override Rocket.API.Collections.TranslationList DefaultTranslations =>
            new Rocket.API.Collections.TranslationList
            {
            };
    }
}
