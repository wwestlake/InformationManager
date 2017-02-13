using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model.EntityMaps
{
    public class DocumentSectionMap : EntityTypeConfiguration<DocumentSection>
    {
        public DocumentSectionMap()
        {
            this.HasMany<TextBlock>(x => x.TextBlocks);
            this.HasMany<DocumentSection>(x => x.Sections);   
        }
    }
}
