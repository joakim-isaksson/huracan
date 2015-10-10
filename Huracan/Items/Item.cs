using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan.Items
{
    class Item
    {
        public readonly string Id;
        public readonly string Name;
        public readonly List<string> Slots;

        public Item(string id, string name, List<string> slots)
        {
            Id = id;
            Name = name;
            Slots = slots;
        }

    }
}
