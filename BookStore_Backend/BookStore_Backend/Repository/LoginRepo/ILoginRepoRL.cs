using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public interface ILoginRepoRL
    {
        bool Login(User user);
        Task<int> AddUser(User user);
    }
}
