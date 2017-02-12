using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
            MetaData = new HashSet<MetaData>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<MetaData> MetaData { get; set; }
    }
}
