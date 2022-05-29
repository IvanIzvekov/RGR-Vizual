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

        public Race(long i)
        {
            Id = i;
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
        public virtual Tournament?  TournamentNavigation { get; set; }
        public static string[] GetAttr()
        {
            return new[] { "Race: IDRace", "Race: Date", "Race: Trace", "Race: Cars", "Race: Len", "Race: Laps" };
        }
        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "IDRace": return Id;
                    case "Date": return Date;
                    case "Trace": return Trace;
                    case "Cars": return Cars;
                    case "Len": return Len;
                    case "Laps": return Laps;
                }
                return null;
            }
        }
    }
}
