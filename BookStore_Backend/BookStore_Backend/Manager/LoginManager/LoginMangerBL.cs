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
        public bool LoginBL(User user)
        {
            return repo.LoginRL(user);
        }
        public Task<int> AddUserBL(User user)
        {
            return repo.AddUserRL(user);
        } 
    }
}
