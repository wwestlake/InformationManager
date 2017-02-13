using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model.EntityMaps
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            this.HasMany<DocumentSection>(x => x.Sections);
            this.HasMany<Author>(x => x.Authors)
                .WithMany(y => y.Documents)
                .Map(x => {
                    x.MapLeftKey("DocumentId");
                    x.MapRightKey("AuthorId");
                    x.ToTable("DocumentAuthor");
                });   
        }
    }
}
