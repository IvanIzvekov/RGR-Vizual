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

        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Id": return Id;
                    case "Name": return Name;
                }
                return null;
            }
        }

        public virtual ICollection<Result> Results { get; set; }
        public static string GetAttr()
        {
            return "Owner: Id";
        }
    }
}
