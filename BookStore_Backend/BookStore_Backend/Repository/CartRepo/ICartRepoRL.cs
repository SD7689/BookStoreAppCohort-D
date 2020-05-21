using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CartRepo
{
    public interface ICartRepoRL
    {
        Task<int> AddToCartRL(Cart cart);
        Cart RemoveCartRL(int CartID);
        int NumOfBookRL();
        IQueryable GetAllCartValueRL();

    }
}
