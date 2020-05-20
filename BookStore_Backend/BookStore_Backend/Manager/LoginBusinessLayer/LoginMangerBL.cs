using Model;
using Repository.LoginRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.LoginManager
{
    public class LoginMangerBL : ILoginManagerBL
    {
        private readonly ILoginRepoRL repo;

        public LoginMangerBL(ILoginRepoRL repo)
        {
            this.repo = repo;
        }
        public bool Login(UserCL user)
        {
            return repo.Login(user);
        }
        public Task<int> AddUser(UserCL user)
        {
            return repo.AddUser(user);
        } 
    }
}
