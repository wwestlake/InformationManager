using LagDaemon.InformationManager.DAL.Model;

namespace LagDaemon.InformationManager.DAL.Repos
{
    public class DocumentRepository : GenericRepository<Document>
    {
        public DocumentRepository(IMContext context) : base(context) { }



    }
}
