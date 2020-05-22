using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.LoginRepo
{
    public interface ILoginRL
    {
        bool Login(UserCL user);
        Task<int> AddUser(UserCL user);
        string Decrypt(string input, string key);
        string Encrypt(string input, string key);
    }
}
