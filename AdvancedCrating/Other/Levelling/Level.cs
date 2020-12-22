using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCrating.Other.Levelling
{
    public class Level
    {
        public string LevelName { get; set; }
        public string LevelExpNeeded { get; set; }

        public Level()
        {
        }

        public Level(string levelname, string levelexpneeded)
        {
            LevelName = levelname;
            LevelExpNeeded = levelexpneeded;
        }
    }
}
