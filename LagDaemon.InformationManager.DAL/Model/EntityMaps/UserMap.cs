using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model.EntityMaps
{
    public class UserMap : EntityTypeConfiguration<User> 
    {
        public UserMap()
        {
            this.HasMany<MetaData>(u => u.MetaData);
        }
    }
}
