using LagDaemon.InformationManager.DAL.Interfaces;
using LagDaemon.InformationManager.DAL.Model;
using Sodium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Repos
{
    public class UserRepository : GenericRepository<User> 
    {
        public UserRepository(IMContext context, ReportException exHandler) : base(context, exHandler) { }

        public void AddUserToGroup(User user, Group group)
        {
            try
            {
                if (!IsUserInGroup(user, group))
                {
                    user.Groups.Add(group);
                    group.Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                exHandler("UserRepository", "AddUserToGroup", ex);
            }
        }

        public void AddUserToGroup(int userid, int groupid)
        {
            try
            {
                var groupRepo = new GroupRepository(context, exHandler);
                var user = GetByID(userid);
                var group = groupRepo.GetByID(groupid);
                AddUserToGroup(user, group);
            }
            catch (Exception ex)
            {
                exHandler("UserRepository", "AddUserToGroup", ex);
            }
        }

        public bool IsUserInGroup(User user, Group group)
        {
            if (user.Groups.Contains(group) && group.Users.Contains(user))
                return true;
            return false; 
        }

        public User CreateUser(string login, string email, string password)
        {
            var user = new User
            {
                Login = login,
                Email = email,
                Password = HashPassword(password),
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                Active = false,
                Validated = false
            };
            Insert(user);
            return user;
        }

        public User ChangePassword(string loginOrEmail, string oldPassword, string newPassword)
        {
            var u = CheckCredentials(loginOrEmail, oldPassword);
            if (u != null)
            {
                u.Password = HashPassword(newPassword);
                return u;
            }
            return null;
        }

        public User CheckCredentials(string loginOrEmail, string password)
        {
            User user;
            if (loginOrEmail.Contains('@'))
            {
                user = Get(u => u.Email.Equals(loginOrEmail)).FirstOrDefault();
            } else
            {
                user = Get(u => u.Login.Equals(loginOrEmail)).FirstOrDefault();
            }
            if (user == null) return null;
            if (VerifyPassword(user.Password, password))
            {
                return user;
            }
            return null;
        }

        private string HashPassword(string clearPassword)
        {
            return PasswordHash.ScryptHashString(clearPassword);
        }

        private bool VerifyPassword(string hash, string password)
        {
            return PasswordHash.ScryptHashStringVerify(hash, password);
        }

    }
}
