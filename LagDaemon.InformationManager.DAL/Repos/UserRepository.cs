using LagDaemon.InformationManager.DAL.Interfaces;
using LagDaemon.InformationManager.DAL.Model;
using LagDaemon.InformationManager.Interfaces;
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

        protected void AddUserToGroup(User user, Group group)
        {
            try
            {
                if (!IsUserInGroup(user, group))
                {
                    user.Groups.Add(group);
                    Update(user);
                }
            }
            catch (Exception ex)
            {
                exHandler(this, new ExceptionEventArgs("UserRepository:AddUserToGroup", ex));
            }
        }

        public ActionResult<User> AddUserToGroup(int userid, int groupid)
        {
            try
            {
                var groupRepo = new GroupRepository(context, exHandler);
                var user = GetByID(userid);
                var group = groupRepo.GetByID(groupid);
                AddUserToGroup(user, group);
                return new ActionResult<User>(user, ResultType.Success);
            }
            catch (Exception ex)
            {
                exHandler(this, new ExceptionEventArgs("UserRepository:AddUserToGroup", ex));
                return new ActionResult<User>(null, ResultType.Failure, ex.ToString());
            }
        }

        public bool IsUserInGroup(User user, Group group)
        {
            if (user.Groups.Contains(group) && group.Users.Contains(user))
                return true;
            return false; 
        }

        public ActionResult<User> CreateUser(string login, string email, string password)
        {
            var checkUser = Get(u => u.Login == login || u.Email == email);
            if (checkUser != null)
            {
                return new ActionResult<User>(null, ResultType.Failure, "User already exists");
            }

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
            return new ActionResult<User>(user, ResultType.Success);
        }

        public ActionResult<User> ChangePassword(string loginOrEmail, string oldPassword, string newPassword)
        {
            var u = CheckCredentials(loginOrEmail, oldPassword);
            if (u.ResultType == ResultType.Failure) return u;
            u.Result.Password = HashPassword(newPassword);
            Update(u.Result);
            return u;
        }

        public ActionResult<User> CheckCredentials(string loginOrEmail, string password)
        {
            User user;
            if (loginOrEmail.Contains('@'))
            {
                user = Get(u => u.Email.Equals(loginOrEmail)).FirstOrDefault();
            } else
            {
                user = Get(u => u.Login.Equals(loginOrEmail)).FirstOrDefault();
            }
            if (user == null) return new ActionResult<User>(null, ResultType.Failure, "Invalid Credentials");
            if (VerifyPassword(user.Password, password))
            {
                return new ActionResult<User>(user, ResultType.Success);
            }
            return new ActionResult<User>(null, ResultType.Failure, "Invalid Credentials");
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
