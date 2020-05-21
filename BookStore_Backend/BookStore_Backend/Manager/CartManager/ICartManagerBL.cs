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
        Task<int> AddToCartBL(Cart cart);
        Cart RemoveCartBL(int CartID);

        
        int NumOfBookBL();

        IQueryable GetAllCartValueBL();

    }
}
