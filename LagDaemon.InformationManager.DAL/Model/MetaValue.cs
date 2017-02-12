using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class MetaValue
    {
        public int MetaValueId {get; set;}
    }

    public class IntegerValue : MetaValue
    {
        public int Value { get; set; }
    }

    public class FloatValue : MetaValue
    {
        public float Value { get; set; }
    }

    public class DoubleValue : MetaValue
    {
        public double Value { get; set; }
    }

    public class BooleanValue : MetaValue
    {
        public bool Value { get; set; }
    }

    public class StringValue : MetaValue
    {
        public string Value { get; set; }
    }

    public class DateTimeValue : MetaValue
    {
        public DateTime Value { get; set; }
    }

}
