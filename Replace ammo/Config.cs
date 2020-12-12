using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_ammo
{
    public class Config : IRocketPluginConfiguration
    {
        public List<AmmoReplace> AmmoReplaces { get; set; }

        public void LoadDefaults() => AmmoReplaces = new List<AmmoReplace>()
        {
            new AmmoReplace(4, 17),
            new AmmoReplace(99, 1006)
        };
    }
}
