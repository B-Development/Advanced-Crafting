using AdvancedCrating.Other.Recipe;
using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdvancedCrating
{
    public class Config : IRocketPluginConfiguration
    {
        public List<Recipe> Recipes { get; set; }
        public void LoadDefaults()
        {

            Recipes = new List<Recipe>()
            {
                new Recipe("GPS", new Reward(1176, 1) new List<string>{"craft.GPS", "craft.default"}, new Ingredient(66, 3), new Ingredient(1175, 1)),
                new Recipe("Military Suppressor", 7, new List<string>{"craft.MSuppressor"}, new Ingredient(66, 4), new Ingredient(149, 2))
            };
        }
    }
}
