using AdvancedCrafting.Other.Recipe;
using AdvancedCrafting.Other.Webhook;
using Rocket.API;
using System.Collections.Generic;

namespace AdvancedCrafting
{
    public class Config : IRocketPluginConfiguration
    {
        public List<Webhook> Webhook { get; set; }

        public List<Recipe> Recipes { get; set; }

        public void LoadDefaults()
        {
            Webhook = new List<Webhook>()
            {
                new Webhook(false, "Webhook Goes Here.", "#26D611", "#F53030")
            };

            Recipes = new List<Recipe>()
            {
                new Recipe("GPS", 1176, new List<string>{"craft.GPS", "craft.default"}, new List<string>(), new Ingredient(66, 3), new Ingredient(1175, 1)),
                new Recipe("Military Suppressor", 7, new List<string>{"craft.MSuppressor"}, new List<string>(), new Ingredient(66, 4), new Ingredient(149, 2)),
                new Recipe("Shadowstalker", 1441, new List<string>(), new List<string>{"328"}, new Ingredient(67, 10))
            };
        }
    }
}
