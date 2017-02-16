using LagDaemon.InformationManager.DAL.Model;
using LagDaemon.InformationManager.DAL.Repos;
using System;

namespace LagDaemon.InformationManager.DAL.Transactions
{
    public class UnitOfWork
    {

        private IMContext context;
        private UserRepository userRepository;
        private GroupRepository groupRepository;

        public UnitOfWork()
        {
            context = ContextFactory.Context;
        }

        public GenericRepository<TEntity> Repository<TEntity>() where TEntity: class
        {
            return new GenericRepository<TEntity>(context);
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public GroupRepository GroupRepository
        {
            get
            {
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GroupRepository(context);
                }
                return groupRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }



 

    }
}
