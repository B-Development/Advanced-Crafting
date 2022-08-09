using System.Collections.Generic;
using System.Linq;

namespace AdvancedCrafting.Other.Recipe
{
    public class Recipe
    {
        public string NameOfRecipe { get; set; }

        public ushort RewardItem { get; set; }

        public List<Permission> Permissions { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Container> Containers { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, ushort rewardItem, List<string> permissions, List<string> containerIds, params Ingredient[] ingredients)
        {
            NameOfRecipe = name;
            RewardItem = rewardItem;
            Permissions = permissions.Select(p => new Permission(p)).ToList();
            Containers = containerIds.Select(c => new Container(c)).ToList();
            Ingredients = new List<Ingredient>(ingredients);
        }
    }
}
