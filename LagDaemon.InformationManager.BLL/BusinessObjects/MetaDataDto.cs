using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.BLL.BusinessObjects
{
    public class MetaDataDto
    {
        public int MetaDataDtoId { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MetaValueDto Value { get; set; }
    }
}
