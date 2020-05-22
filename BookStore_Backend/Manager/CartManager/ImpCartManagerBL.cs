using Model;
using Repository.CartRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.CartManager
{
    public class ImpCartManagerBL:ICartManagerBL
    {
        private readonly ICartRL manager;
        public ImpCartManagerBL(ICartRL manager)
        {
            this.manager = manager;
        }

        public Task<int> AddToCart(CartCL cart)
        {
            return this.manager.AddToCart(cart);
        }

        public IQueryable GetAllCartValue()
        {
            return this.manager.GetAllCartValue();
        }

        public CartCL RemoveCart(int CartID)
        {
            return this.manager.RemoveCart(CartID);
        }
        public int NumOfBook()
        {
            return this.manager.NumOfBook();
        }
    }
}
