using AdvancedCrating.Other;
using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdvancedCrating
{
    public class Config : IRocketPluginConfiguration
    {
        public List<Recipe> Recipes { get; set; }

        public void LoadDefaults() => Recipes = new List<Recipe>()
        {
            new Recipe("GPS", 1176, "craft.GPS", new Ingredient(66, 3), new Ingredient(1175, 1)),
            new Recipe("Military Suppressor", 7, "craft.MSuppressor", new Ingredient(149, 2), new Ingredient(66, 2))
        };
    }
}
