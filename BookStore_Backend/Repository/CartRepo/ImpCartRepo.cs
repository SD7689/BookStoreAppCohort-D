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
        public  List<Cart> cartList = new List<Cart>();
        public  List<Book> getAllCartByBookType = new List<Book>();

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

        public IEnumerable<Book> GetAllCartValue()
        {
            cartList= bookStoreDB.Cart.ToList();
            for(int i=0;i<cartList.Count;i++)
            {
                getAllCartByBookType.Add(bookStoreDB.Book.Find(cartList[i].BookId));
            }
            return getAllCartByBookType;
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
