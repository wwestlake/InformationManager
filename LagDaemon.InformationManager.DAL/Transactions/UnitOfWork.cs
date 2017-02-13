using LagDaemon.InformationManager.DAL.Interfaces;
using LagDaemon.InformationManager.DAL.Model;
using LagDaemon.InformationManager.DAL.Repos;
using LagDaemon.InformationManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Transactions
{
    public class UnitOfWork : IDisposable
    {
        public event ReportException ExceptionEvent;

        private IMContext context = new IMContext();
        private UserRepository userRepository;
        private GroupRepository groupRepository;

        public GenericRepository<TEntity> Repository<TEntity>() where TEntity: class
        {
            return new GenericRepository<TEntity>(context, FireExceptionEvent);
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context, FireExceptionEvent);
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
                    this.groupRepository = new GroupRepository(context, FireExceptionEvent);
                }
                return groupRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void FireExceptionEvent(object sender, ExceptionEventArgs args)
        {
            if (ExceptionEvent != null)
            {
                ExceptionEvent.Invoke(sender, args);
            }
        }

    }
}
