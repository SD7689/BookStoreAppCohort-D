using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CartRepo
{
    public interface ICartRepo
    {
        Task<int> AddToCart(Cart cart);
        Cart RemoveCart(int CartID);
        int NumOfBook();
        IQueryable GetAllCartValue();

    }
}
