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

        public Task<int> AddToCartBL(Cart cart)
        {
            return this.manager.AddToCartRL(cart);
        }

        public IQueryable GetAllCartValueBL()
        {
            return this.manager.GetAllCartValueRL();
        }

        public Cart RemoveCartBL(int CartID)
        {
            return this.manager.RemoveCartRL(CartID);
        }
        public int NumOfBookBL()
        {
            return this.manager.NumOfBookRL();
        }
    }
}
