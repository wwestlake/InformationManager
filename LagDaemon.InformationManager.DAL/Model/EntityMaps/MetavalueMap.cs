using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model.EntityMaps
{
    public class MetaValueMap : EntityTypeConfiguration<MetaValue>
    {
        public MetaValueMap()
        {
            
        }
    }

    public class IntegerValueMap : EntityTypeConfiguration<IntegerValue>
    {
        public IntegerValueMap()
        {
            Property(x => x.Value).HasColumnName("IntegerValue");
        }
    }

    public class FloatValueMap : EntityTypeConfiguration<FloatValue>
    {
        public FloatValueMap()
        {
            Property(x => x.Value).HasColumnName("FloatValue");
        }
    }

    public class DoubleValueMap : EntityTypeConfiguration<DoubleValue>
    {
        public DoubleValueMap()
        {
            Property(x => x.Value).HasColumnName("DoubleValue");
        }
    }

    public class BooleanValueMap : EntityTypeConfiguration<BooleanValue>
    {
        public BooleanValueMap()
        {
            Property(x => x.Value).HasColumnName("BooleanValue");
        }
    }

    public class StringValueMap : EntityTypeConfiguration<StringValue>
    {
        public StringValueMap()
        {
            Property(x => x.Value).HasColumnName("StringValue");
        }
    }

    public class DateTimeValueMap : EntityTypeConfiguration<DateTimeValue>
    {
        public DateTimeValueMap()
        {
            Property(x => x.Value).HasColumnName("DateTimeValue");
        }
    }

}
