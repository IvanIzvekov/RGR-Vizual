using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Owner
    {
        public Owner()
        {
            Results = new HashSet<Result>();
        }
        public Owner(long i)
        {
            Id = i;
            Results = new HashSet<Result>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Result> Results { get; set; }
    }
}
