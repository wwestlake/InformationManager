using LagDaemon.InformationManager.BLL.BusinessObjects;
using LagDaemon.InformationManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LagDaemon.InformationManager.DAL.Transactions;
using LagDaemon.InformationManager.DAL.Repos;
using AutoMapper;
using LagDaemon.InformationManager.DAL.Model;

namespace LagDaemon.InformationManager.BLL
{
    public class UserManager
    {
        private UnitOfWork uow;
        private UserRepository urepo;

        public UserManager(UnitOfWork uow)
        {
            this.uow = uow;
            this.urepo = uow.UserRepository;
        }

        public IEnumerable<User> All
        {
            get
            {
                return urepo.Get();
            }
        }

        public void Delete(User ent)
        {
            urepo.Delete(ent);
        }

        public void Insert(User ent)
        {
            urepo.Insert(ent);
        }

        public void Save()
        {
            uow.Save();

        }

        public IEnumerable<User> Select(Expression<Func<User, bool>> filter)
        {
            return urepo.Get(filter);
        }

        public void Update(User ent)
        {
            urepo.Update(ent);
        }
    }
}
