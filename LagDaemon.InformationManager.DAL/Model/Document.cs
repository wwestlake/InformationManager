using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class Document
    {
        public Document()
        {
            Sections = new HashSet<DocumentSection>();
        }

        public int DocumentId { get; set; }
        public ICollection<Author> Authors { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
        public TextBlock Synopsys { get; set; }
        public ICollection<DocumentSection> Sections { get; set; }  
    }
}
