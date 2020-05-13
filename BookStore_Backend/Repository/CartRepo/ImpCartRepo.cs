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

        public IQueryable GetAllCartValue()
        {
            var result = this.bookStoreDB.Cart.Join(this.bookStoreDB.Book,
                Cart => Cart.BookId,
                Book => Book.BookID,
                (Cart, Book) =>
                new
                {
                    bookId = Book.BookID,
                    bookTitle = Book.BookTitle,
                    authorName = Book.AuthorName,
                    bookImage = Book.BookImage,
                    bookPrice = Book.BookPrice,
                    numOfCopies = Cart.BooksCount
                });
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
        public int NumOfBook()
        {
            int count = bookStoreDB.Cart.Count<Cart>();
            return count;
        }
    }
}
