using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Driver
    {
        public Driver()
        {
            Results = new HashSet<Result>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Born { get; set; }
        public string? Home { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
