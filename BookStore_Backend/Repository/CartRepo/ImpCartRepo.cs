using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CartRepo
{
    public class ImpCartRepo:ICartRepo
    {
        private readonly BookStoreDBContext bookStoreDB;

        public ImpCartRepo(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }

        public Task<int> AddToCart(Cart cart)
        {
            bookStoreDB.Cart.Add(cart);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public Cart RemoveCart(int CartID)
        {
            Cart cart = bookStoreDB.Cart.Find(CartID);
            if (cart != null)
            {
                bookStoreDB.Cart.Remove(cart);
                bookStoreDB.SaveChanges();
            }
            return cart;
        }
    }
}
