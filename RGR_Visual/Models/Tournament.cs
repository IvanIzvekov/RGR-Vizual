using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Tournament
    {
        public Tournament()
        {

        }
        public Tournament(long i)
        {
            Id = i;
        }
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Race> Races { get; set; }
    }
}
