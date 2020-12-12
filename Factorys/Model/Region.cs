using System.Collections.Generic;

namespace Factorys.Model
{
    public class Region
    {
        public string Name;
        public List<ulong> Owner;
        public List<ulong> Members;

        public void AddedOwner(ulong owner)
        {
            if (Owner == null)
                Owner = new List<ulong>();

            if (Members == null)
                Members = new List<ulong>();

            if (Members.Contains(owner))
                Members.Remove(owner);

            if (Owner.Contains(owner))
                return;
            Owner.Add(owner);
        }
        public void AddMember(ulong member)
        {
            if (Owner == null)
                Owner = new List<ulong>();

            if (Members == null)
                Members = new List<ulong>();

            if (Owner.Contains(member) || Members.Contains(member))
                return;
            Members.Add(member);
        }
        public void RemoveMember(ulong member)
        {
            RemoveOwner(member);
            if (Members != null && Members.Contains(member))
                Members.Remove(member);
        }

        public void RemoveOwner(ulong member)
        {
            if (Owner != null && Owner.Contains(member))
                Owner.Remove(member);
        }
    }
}
