using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CartRepo
{
    public interface ICartRL
    {
        Task<int> AddToCart(CartCL cart);
        CartCL RemoveCart(int CartID);
        int NumOfBook();
        IQueryable GetAllCartValue();

    }
}
