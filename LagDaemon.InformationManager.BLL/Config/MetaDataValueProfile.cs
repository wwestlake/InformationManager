using AutoMapper;
using LagDaemon.InformationManager.BLL.BusinessObjects;
using LagDaemon.InformationManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.BLL.Config
{
    public class MetaDataValueProfile : Profile
    {
        public MetaDataValueProfile()
        {
            CreateMap<MetaValue, MetaValueDto>();
            CreateMap<IntegerValue, IntegerValueDto>();
            CreateMap<FloatValue, FloatValueDto>();
            CreateMap<DoubleValue, DoubleValueDto>();
            CreateMap<BooleanValue, BooleanValueDto>();
            CreateMap<StringValue, StringValueDto>();
            CreateMap<DateTimeValue, DateTimeValueDto>();

            CreateMap<MetaValueDto, MetaValue>();
            CreateMap<IntegerValueDto, IntegerValue>();
            CreateMap<FloatValueDto, FloatValue>();
            CreateMap<DoubleValueDto, DoubleValue>();
            CreateMap<BooleanValueDto, BooleanValue>();
            CreateMap<StringValueDto, StringValue>();
            CreateMap<DateTimeValueDto, DateTimeValue>();

        }
    }
}
