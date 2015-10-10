using Huracan.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan.Character
{
    class Character
    {
        readonly Attributes BaseStats;
        readonly Attributes Stats;
        readonly Dictionary<Slot, Item> Gear;
    }
}
