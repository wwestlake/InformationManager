using LagDaemon.InformationManager.DAL.Interfaces;
using LagDaemon.InformationManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Repos
{
    public class DocumentRepository : GenericRepository<Document>
    {
        public DocumentRepository(IMContext context, ReportException exHandler) : base(context, exHandler) { }



    }
}
