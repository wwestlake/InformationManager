using LagDaemon.InformationManager.DAL.Model;

namespace LagDaemon.InformationManager.DAL.Repos
{
    public class GroupRepository : GenericRepository<Group>
    {
        public GroupRepository(IMContext context) 
            : base(context) { }

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
