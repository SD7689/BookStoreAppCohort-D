using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.LoginManager
{
    public interface ILoginManagerBL
    {
        bool Login(User user);
        Task<int> AddUser(User user);
    }
}
