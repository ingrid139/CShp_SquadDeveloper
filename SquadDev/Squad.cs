using System;
using System.Collections.Generic;
using System.Text;

namespace SquadDev
{
    public class Squad
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? TechLeaderId { get; set; }
    }
}
