using LagDaemon.InformationManager.BLL.BusinessObjects;
using System.Collections.Generic;
using LagDaemon.InformationManager.DAL.Model;
using AutoMapper;
using LagDaemon.InformationManager.DAL.Transactions;

namespace LagDaemon.InformationManager.Services
{
    public class UserService : IUserService
    {
        private UnitOfWork uow;
        public UserService(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<UserDto> AllUsers
        {
            get
            {
                return Mapper.Map<IEnumerable<UserDto>>(uow.UserRepository.Get());
            }
        }

        public UserDto ChangePassword(UserDto user, string oldPassword, string newPassword)
        {
            var u = uow.UserRepository.ChangePassword(user.Login, oldPassword, newPassword);
            uow.Save();
            if (u != null) return Mapper.Map<UserDto>( u );
            return null;
        }

        public UserDto CheckCredentials(string login, string password)
        {
            var u = uow.UserRepository.CheckCredentials(login, password);
            if (u != null) return Mapper.Map<UserDto>(u);
            return null;
        }

        public UserDto CreateUser(string login, string email, string password)
        {
            var u = uow.UserRepository.CreateUser(login, email, password);
            uow.Save();
            if (u != null) return Mapper.Map<UserDto>(u);
            return null;
        }

        public void DeleteUser(UserDto user)
        {
            uow.UserRepository.Delete(user.UserId);
            uow.Save();
        }

        public void UpdateUser(UserDto user)
        {
            var u = Mapper.Map<User>(user);
            uow.UserRepository.Update(u);
            uow.Save();
        }
    }
}
