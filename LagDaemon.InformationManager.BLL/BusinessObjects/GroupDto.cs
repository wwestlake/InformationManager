using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.BLL.BusinessObjects
{
    public class GroupDto
    {
        public GroupDto()
        {
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual HashSet<MetaDataDto> MetaData { get; set; }
    }
}
