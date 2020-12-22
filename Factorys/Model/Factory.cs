using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Model
{
    public class Factory
    {
        public ushort FactoryItem { get; set; }
        public string FactoryZoneName { get; set; }
        public List<Upgrade> Upgrades { get; set; }

        public Factory()
        {
        }

        public Factory(string factoryzonename, ushort factoryitem, params Upgrade[] upgrades)
        {
            FactoryZoneName = factoryzonename;
            FactoryItem = factoryitem;
            Upgrades = new List<Upgrade>(upgrades);
        }
    }
}
