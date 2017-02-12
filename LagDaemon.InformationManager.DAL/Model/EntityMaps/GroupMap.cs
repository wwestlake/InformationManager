using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model.EntityMaps
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.HasMany<User>(u => u.Users)
                .WithMany(g => g.Groups)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("GroupId");
                    cs.ToTable("UserGroups");
                });

            this.HasMany<MetaData>(m => m.MetaData);
        }
    }
}
