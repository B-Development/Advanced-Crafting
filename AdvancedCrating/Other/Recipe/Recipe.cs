using System.Collections.Generic;
using System.Linq;

namespace AdvancedCrating.Other.Recipe
{
    public class Recipe
    {
        public string NameOfRecipe { get; set; }
        public ushort RewardItem { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, ushort rewardItem, List<string> permissions, params Ingredient[] ingredients)
        {
            NameOfRecipe = name;
            RewardItem = rewardItem;
            Permissions = permissions.Select(p => new Permission(p)).ToList();
            Ingredients = new List<Ingredient>(ingredients);
        }
    }
}