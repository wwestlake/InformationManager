using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.BLL.BusinessObjects
{
    public class UserDto
    {
        public UserDto()
        {
            Groups = new HashSet<GroupDto>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; }
        public bool Validated { get; set; }
        public virtual HashSet<GroupDto> Groups { get; set; }
        public virtual HashSet<MetaDataDto> MetaData { get; set; }
        
    }
}
