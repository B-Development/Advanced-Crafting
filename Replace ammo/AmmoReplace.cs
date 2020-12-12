using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_ammo
{
    public class AmmoReplace
    {
        public ushort Item { get; set; }
        public ushort Ammo { get; set; }

        public AmmoReplace()
        {
        }

        public AmmoReplace(ushort item, ushort ammo)
        {
            Item = item;
            Ammo = ammo;
        }
    }
}
