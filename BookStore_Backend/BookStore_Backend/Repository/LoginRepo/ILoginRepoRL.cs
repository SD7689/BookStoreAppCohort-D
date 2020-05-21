using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.LoginRepo
{
    public interface ILoginRepoRL
    {
        bool LoginRL(User user);
        Task<int> AddUserRL(User user);
    }
}
