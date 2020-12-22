using System.Collections.Generic;
using System.Xml.Serialization;
using Rocket.API;
using SDG.Unturned;
using Factorys.Model;

namespace Factorys
{
    public class Config : IRocketPluginConfiguration
    {
        public List<Factory> Factorys { get; set; }

        public void LoadDefaults() => Factorys = new List<Factory>()
        {
            new Factory("Factory-1", 75, new Upgrade(false, 10, 5)),
            new Factory("Factory-2", 67, new Upgrade(true, 10, 5)),
        };
    }
}
