using BookStoreCommonLayer;
using BookStoreRepositoryLayer.LoginRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.LoginManager
{
    public class LoginMangerBL : ILoginManagerBL
    {
        private readonly ILoginRepoRL repo;

        public LoginMangerBL(ILoginRepoRL repo)
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
