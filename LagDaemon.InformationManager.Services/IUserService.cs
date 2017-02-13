using LagDaemon.InformationManager.BLL.BusinessObjects;
using LagDaemon.InformationManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.Services
{
    public interface IUserService : IService
    {
        IEnumerable<UserDto> AllUsers { get; }
        void DeleteUser(UserDto user);
        ActionResult<UserDto> CreateUser(string login, string email, string password);
        void UpdateUser(UserDto user);
        ActionResult<UserDto> CheckCredentials(string login, string password);
        ActionResult<UserDto> AddUserToGroup(UserDto user, GroupDto group);
        ActionResult<UserDto> ChangePassword(UserDto user, string oldPassword, string newPassword);
    }
}
