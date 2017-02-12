using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.BLL.BusinessObjects
{
    public class MetaValueDto
    {
        public int MetaValueDtoId { get; set; }
    }

    public class IntegerValueDto : MetaValueDto
    {
        public int Value { get; set; }
    }

    public class FloatValueDto : MetaValueDto
    {
        public float Value { get; set; }
    }

    public class DoubleValueDto : MetaValueDto
    {
        public double Value { get; set; }
    }

    public class BooleanValueDto : MetaValueDto
    {
        public bool Value { get; set; }
    }

    public class StringValueDto : MetaValueDto
    {
        public string Value { get; set; }
    }

    public class DateTimeValueDto : MetaValueDto
    {
        public DateTime Value { get; set; }
    }

}
