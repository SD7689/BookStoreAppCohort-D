using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.LoginManager
{
    public interface ILoginManager
    {
        Object Login(string email, string password);
        Task<int> AddUser(User user);
    }
}
