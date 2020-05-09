using Model;
using Repository.CartRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CartManager
{
    public class ImpCartManager:ICartManager
    {
        private readonly ICartRepo manager;
        public ImpCartManager(ICartRepo manager)
        {
            this.manager = manager;
        }

        public Task<int> AddToCart(Cart cart)
        {
            return this.manager.AddToCart(cart);
        }

        public IEnumerable<Book> GetAllCartValue()
        {
            return this.manager.GetAllCartValue();
        }

        public Cart RemoveCart(int CartID)
        {
            return this.manager.RemoveCart(CartID);
        }
    }
}
