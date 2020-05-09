using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Cart> GetAllCartValue()
        {
            return bookStoreDB.Cart;
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
        public int NumOfBook()
        {
            int count = bookStoreDB.Cart.Count<Cart>();
            return count;
        }
    }
}
