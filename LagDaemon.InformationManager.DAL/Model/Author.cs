using System.Collections.Generic;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class Author
    {
        public Author()
        {
            Documents = new HashSet<Document>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}