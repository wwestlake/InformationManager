using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using LagDaemon.InformationManager.DAL.Model.EntityMaps;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class IMContext : DbContext
    {
        public IMContext() : base("name=InformationManager")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new MetaValueMap());
            modelBuilder.Configurations.Add(new IntegerValueMap());
            modelBuilder.Configurations.Add(new FloatValueMap());
            modelBuilder.Configurations.Add(new DoubleValueMap());
            modelBuilder.Configurations.Add(new BooleanValueMap());
            modelBuilder.Configurations.Add(new StringValueMap());
            modelBuilder.Configurations.Add(new DateTimeValueMap());

            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new DocumentSectionMap());
            modelBuilder.Configurations.Add(new TextBlockMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
