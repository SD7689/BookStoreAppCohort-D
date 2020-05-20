using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public interface ILoginRepoRL
    {
        bool Login(UserCL user);
        Task<int> AddUser(UserCL user);
    }
}
