using System;
using System.Collections.Generic;

namespace RGR_Visual.Models
{
    public partial class Driver : Table
    {
        public Driver()
        {
            Results = new HashSet<Result>();
        }
        public Driver(long i)
        {
            Id = i;
            Results = new HashSet<Result>();
        }
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Born { get; set; }
        public string? Home { get; set; }

        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Id": return Id;
                    case "Name": return Name;
                    case "Born": return Born;
                    case "Home": return Home;
                }
                return null;
            }
        }

        public virtual ICollection<Result> Results { get; set; }
        public bool Equals(Driver? other)
        {
            return (this.Name == other.Name);
        }
        public static string[] GetAttr()
        {
            return new[] { "Driver: Id", "Driver: Name", "Driver: Born", "Driver: Home" };
        }
    }
}
