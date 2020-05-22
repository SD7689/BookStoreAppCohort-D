using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Manager.CartManager
{
    public interface ICartManagerBL
    {
        Task<int> AddToCart(CartCL cart);
        CartCL RemoveCart(int CartID);

        
        int NumOfBook();

        IQueryable GetAllCartValue();

    }
}
