using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Result
    {
        public long Id { get; set; }
        public long? IdDriver { get; set; }
        public long? IdRace { get; set; }
        public long? IdOwner { get; set; }
        public long? StartPos { get; set; }
        public long? FinishPos { get; set; }
        public long? Number { get; set; }

        public virtual Driver? IdDriverNavigation { get; set; }
        public virtual Owner? IdOwnerNavigation { get; set; }
        public virtual Race? IdRaceNavigation { get; set; }
    }
}
