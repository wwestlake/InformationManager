using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
            MetaData = new HashSet<MetaData>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; }
        public bool Validated { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<MetaData> MetaData { get; set; }
    }
}
