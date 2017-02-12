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
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
        }
    }
}
