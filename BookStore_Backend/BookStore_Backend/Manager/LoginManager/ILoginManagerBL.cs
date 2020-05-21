using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.LoginManager
{
    public interface ILoginManagerBL
    {
        bool LoginBL(User user);
        Task<int> AddUserBL(User user);
    }
}
