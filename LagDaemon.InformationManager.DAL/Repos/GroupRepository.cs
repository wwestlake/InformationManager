using LagDaemon.InformationManager.DAL.Interfaces;
using LagDaemon.InformationManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Repos
{
    public class GroupRepository : GenericRepository<Group>
    {
        public GroupRepository(IMContext context, ReportException exHandler) 
            : base(context, exHandler) { }

        public Group CreateGroup(string name, string description)
        {
            var group = new Group
            {
                Name = name,
                Description = description
            };
            Insert(group);
            return group;
        }


    }
}
