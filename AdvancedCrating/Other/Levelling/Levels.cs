using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCrating.Other.Levelling
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
