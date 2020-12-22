using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Model
{
    public class Upgrade
    {
        public bool Upgradeable { get; set; }
        public int MaxCapacity { get; set; }
        public int MaxSpeed { get; set; }

        public Upgrade()
        {
        }

        public Upgrade(bool upgradable, int maxcapacity, int maxspeed)
        {
            Upgradeable = upgradable;
            MaxCapacity = maxcapacity;
            MaxSpeed = maxspeed;
        }
    }
}
