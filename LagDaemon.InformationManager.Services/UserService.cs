using LagDaemon.InformationManager.BLL.BusinessObjects;
using System.Collections.Generic;
using LagDaemon.InformationManager.DAL.Model;
using AutoMapper;
using LagDaemon.InformationManager.DAL.Transactions;
using LagDaemon.InformationManager.Interfaces;

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

        public ActionResult<UserDto> ChangePassword(UserDto user, string oldPassword, string newPassword)
        {
            var u = uow.UserRepository.ChangePassword(user.Login, oldPassword, newPassword);
            uow.Save();
            if (u.ResultType == ResultType.Success)
            {
                uow.Save();
                return new ActionResult<UserDto>(Mapper.Map<UserDto>(u.Result), ResultType.Success);
            }
            return new ActionResult<UserDto>(user, ResultType.Failure, u.ErrorMessage);
        }

        public ActionResult<UserDto> AddUserToGroup(UserDto user, GroupDto group)
        {
            var u = uow.UserRepository.AddUserToGroup(user.UserId, group.GroupId);
            if (u.ResultType == ResultType.Success)
            {
                uow.Save();
                return new ActionResult<UserDto>(Mapper.Map<UserDto>(u.Result), ResultType.Success);
            }
            return new ActionResult<UserDto>(user, ResultType.Failure, u.ErrorMessage);
        }

        public ActionResult<UserDto> CheckCredentials(string login, string password)
        {
            var u = uow.UserRepository.CheckCredentials(login, password);
            if (u.ResultType == ResultType.Success)
            {
                uow.Save();
                return new ActionResult<UserDto>(Mapper.Map<UserDto>(u.Result), ResultType.Success);
            }
            return new ActionResult<UserDto>(null, ResultType.Failure, u.ErrorMessage);
        }

        public ActionResult<UserDto> CreateUser(string login, string email, string password)
        {
            var u = uow.UserRepository.CreateUser(login, email, password);
            if (u.ResultType == ResultType.Success)
            {
                uow.Save();
                return new ActionResult<UserDto>(Mapper.Map<UserDto>(u.Result), ResultType.Success);
            }
            return new ActionResult<UserDto>(null, ResultType.Failure, u.ErrorMessage);
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
