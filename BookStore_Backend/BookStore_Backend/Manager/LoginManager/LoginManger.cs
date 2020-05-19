using Model;
using Repository.LoginRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.LoginManager
{
    public class LoginManger : ILoginManager
    {
        private readonly ILoginRepo repo;

        public LoginManger(ILoginRepo repo)
        {
            this.repo = repo;
        }
        public bool Login(User user)
        {
            return repo.Login(user);
        }
        public Task<int> AddUser(User user)
        {
            return repo.AddUser(user);
        } 
    }
}
