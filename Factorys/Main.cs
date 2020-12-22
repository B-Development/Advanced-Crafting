using Factorys.Model;
using Game4Freak.AdvancedZones;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Factorys
{
    public class Main : RocketPlugin<Config>
    {
        public delegate void onZoneLeaveHandler(UnturnedPlayer player, Zone zone, Vector3 lastPos);
        public static event onZoneLeaveHandler onZoneLeave;

        public delegate void onZoneEnterHandler(UnturnedPlayer player, Zone zone, Vector3 lastPos);
        public static event onZoneEnterHandler onZoneEnter;
        protected override void Load()
        {
            onZoneLeave += onZoneLeft;
            onZoneEnter += onZoneEntered;
        }

        private void onZoneLeft(UnturnedPlayer player, Zone zone, Vector3 lastPos)
        {
            Configuration.Instance.Factorys.ForEach(f => factory(f.FactoryZoneName, f.FactoryItem, f.Upgrades, zone, player, lastPos));
        }

        private void onZoneEntered(UnturnedPlayer player, Zone zone, Vector3 lastPos)
        {
            Configuration.Instance.Factorys.ForEach(f => factory(f.FactoryZoneName, f.FactoryItem, f.Upgrades, zone, player, lastPos));
        }
        private void factory(string factoryZoneName, ushort factoryItem, List<Upgrade> upgrades, Zone zone, UnturnedPlayer player, Vector3 lastPos)
        {
            if(zone.name == factoryZoneName)
            {

            }
        }

        protected override void Unload()
        {
        }
    }
}
