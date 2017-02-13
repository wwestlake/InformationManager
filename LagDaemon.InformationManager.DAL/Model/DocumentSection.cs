using System.Collections.Generic;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class DocumentSection
    {
        public DocumentSection()
        {
            Sections = new HashSet<DocumentSection>();
            TextBlocks = new HashSet<TextBlock>();
        }

        public int DocumentSectionId { get; set; }
        public ICollection<DocumentSection> Sections { get; set; }
        public ICollection<TextBlock> TextBlocks { get; set; }
    }
}