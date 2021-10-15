using System.Collections.Generic;
using System.Linq;

namespace AdvancedCrating.Other.Recipe
{
    public class Reward
    {
        public ushort RewardItem { get; set; }
        public int Amount { get; set; }

        public Reward()
        {
        }

        public Reward(ushort reward, int amount)
        {
            RewardItem = reward;
            Amount = amount;
        }
    }
}