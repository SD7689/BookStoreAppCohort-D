using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Manager.CartManager
{
    public interface ICartManager
    {
        Task<int> AddToCart(Cart cart);
        Cart RemoveCart(int CartID);
        int NumOfBook();
<<<<<<< HEAD
        IEnumerable<Book> GetAllCartValue();
=======

        IQueryable GetAllCartValue();
>>>>>>> 8339a79220b48b57bb8a3f802dd799c1a3b8d90c

    }
}
