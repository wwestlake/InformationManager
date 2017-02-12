using AutoMapper;
using LagDaemon.InformationManager.BLL.BusinessObjects;
using LagDaemon.InformationManager.DAL.Model;
using LagDaemon.InformationManager.DAL.Transactions;
using LagDaemon.InformationManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.MgtConsole
{
    class Program
    {
        static void Init()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[]
                {
                    typeof(BLL.BusinessObjects.UserDto)
                }));
                
        }

        static void Main(string[] args)
        {
            Init();

            var userv = new UserService(new UnitOfWork());

            userv.CreateUser("wwestlake", "wwestlake@lagdaemon.com", "password");
            userv.CreateUser("wwestlake1", "wwestlake1@lagdaemon.com", "password");
            userv.CreateUser("wwestlake2", "wwestlake2@lagdaemon.com", "password");

            

            var ulist = userv.AllUsers;

            foreach (var u in ulist)
            {
                Console.WriteLine("{0},{1},{2}", u.Login, u.Email, u.Created );
            }

            Console.WriteLine("Press Any Key");
            Console.ReadKey();
        }
    }
}
