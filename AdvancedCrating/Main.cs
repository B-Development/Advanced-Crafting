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
            { "successful-Craft", "Congratulations. You have Crafted the item." },
            {"no-perm-for-craft", "You do not have permission for this craft!" },
            {"specify-recipe", "Please specify a recipe." },
            {"please-add-ingredients", "Player add ingredients to the storage." },
            {"recipe-doesnt-exist", "This recipe does not exist."},
            {"webhook_fail_recipe", "** [{0}](https://steamcommunity.com/profiles/{1}) ** \n failed to craft: {2}" },
            {"webhook_success_recipe", "** [{0}](https://steamcommunity.com/profiles/{1}) ** \n succeeded to craft: {2}" }
        };

        protected override void Load()
        {
            Instance = this;
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded", ConsoleColor.Yellow);
        }
        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded", ConsoleColor.Yellow);
        }
    }
}
