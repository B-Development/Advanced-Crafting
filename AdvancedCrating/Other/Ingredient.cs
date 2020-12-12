namespace AdvancedCrating.Other
{
    public class Ingredient
    {
        public ushort Item { get; set; }
        public int Amount { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(ushort item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}
