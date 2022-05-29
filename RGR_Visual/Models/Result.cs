using RGR_Visual.Models;
using System;
using System.Collections.Generic;

namespace RGR_Visual
{
    public partial class Result
    {
        public Result()
        {
            
        }
        public Result(long i)
        {
            Id = i;
        }

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
        public static string[] GetAttr()
        {
            return new[] { "Result: IDResult", "Result: IdDriver", "Result: IdRace", "Result: IdOwner", "Result: StartPos", "Result: FinishPos", "Result: Number" };
        }
        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "IDResult": return Id;
                    case "IdDriver": return IdDriver;
                    case "IdRace": return IdRace;
                    case "IdOwner": return IdOwner;
                    case "StartPos": return StartPos;
                    case "FinishPos": return FinishPos;
                    case "Number": return Number;
                }
                return null;
            }
        }
    }
}
