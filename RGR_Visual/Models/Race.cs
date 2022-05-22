using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Race
    {
        public Race()
        {
            Results = new HashSet<Result>();
        }

        public long Id { get; set; }
        public string? Date { get; set; }
        public string? Trace { get; set; }
        public long? Cars { get; set; }
        public string? Len { get; set; }
        public long? Laps { get; set; }
        public long? IdTournament { get; set; }
        

        public virtual ICollection<Result> Results { get; set; }
    }
}
