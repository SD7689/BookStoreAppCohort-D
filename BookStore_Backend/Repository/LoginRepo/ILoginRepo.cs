using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public interface ILoginRepo
    {
        bool Login(string email, string password);
        Task<int> AddUser(User user);
    }
}
