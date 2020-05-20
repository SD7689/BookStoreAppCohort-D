using BookStoreCommonLayer;
using BookStoreRepositoryLayer.CartRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.CartManager
{
    public class ImpCartManagerBL:ICartManagerBL
    {
        private readonly ICartRepoRL manager;
        public ImpCartManagerBL(ICartRepoRL manager)
        {
            this.manager = manager;
        }

        public Task<int> AddToCart(Cart cart)
        {
            return this.manager.AddToCart(cart);
        }

        public IQueryable GetAllCartValue()
        {
            return this.manager.GetAllCartValue();
        }

        public Cart RemoveCart(int CartID)
        {
            return this.manager.RemoveCart(CartID);
        }
        public int NumOfBook()
        {
            return this.manager.NumOfBook();
        }
    }
}
