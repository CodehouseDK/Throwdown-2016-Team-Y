using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamY.Domain.Octopus
{
    public class OctopusBaseItem<TItem>
    {
        public string ItemType { get; set; }
        public bool IsStale { get; set; }
        public int TotalResults { get; set; }
        public List<TItem> Items { get; set; }
    }
}
