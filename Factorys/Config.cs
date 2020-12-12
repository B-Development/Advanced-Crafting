using System.Collections.Generic;
using System.Xml.Serialization;
using Factorys.Model;
using Rocket.API;
using SDG.Unturned;

namespace Factorys
{
    public class Config : IRocketPluginConfiguration
    {
        public List<Region> Regions { get; private set; }

        public void LoadDefaults()
        {
            Regions = new List<Region>();
        }
    }
}
