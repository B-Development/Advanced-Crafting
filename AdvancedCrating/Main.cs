using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;

namespace AdvancedCrating
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "no_object", "No object was found in your line of sight." },
            { "storage_open", "Opened storage." },
            { "invalid_storage", "The object that you are looking at is not a storage unit." },
            { "Successful-Craft", "Congratulations. You have Crafted the item." }
        };

        protected override void Load()
        {
            base.Load();
            Instance = this;
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded", ConsoleColor.Yellow);
        }
        protected override void Unload()
        {
            base.Unload();
            Logger.Log($"{Name} has been unloaded", ConsoleColor.Yellow);
        }
    }
}
