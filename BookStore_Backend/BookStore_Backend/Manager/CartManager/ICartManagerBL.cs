using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BookStoreBussinessLayer.CartManager
{
    public interface ICartManagerBL
    {
        Task<int> AddToCart(Cart cart);
        Cart RemoveCart(int CartID);

        
        int NumOfBook();

        IQueryable GetAllCartValue();

    }
}
