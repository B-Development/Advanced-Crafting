using System.Collections.Generic;

namespace AdvancedCrafting.Other.Levelling
{
    public class Levels
    {
        public bool Enabled { get; set; }

        public List<Level> Level { get; set; }

        public Levels()
        {

        }

        public Levels(bool enabled, List<Level> levels)
        {
            Enabled = enabled;
            Level = levels;
        }
    }
}
