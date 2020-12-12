using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCrating.Other
{
    public class Recipe
    {
        public string NameOfRecipe { get; set; }
        public ushort RewardItem { get; set; }
        public string Permission { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, ushort rewardItem, string permission, params Ingredient[] ingredients)
        {
            NameOfRecipe = name;
            RewardItem = rewardItem;
            Permission = permission;
            Ingredients = new List<Ingredient>(ingredients);
        }
    }
}
