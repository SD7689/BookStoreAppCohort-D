using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.CartRepo
{
    public class ImpCartRepoRL:ICartRepoRL
    {
        private readonly BookStoreDBContext bookStoreDB;
        public ImpCartRepoRL(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }

        public Task<int> AddToCartRL(Cart cart)
        {
            bookStoreDB.Cart.Add(cart);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public IQueryable GetAllCartValueRL()
        {
            var result = this.bookStoreDB.Cart.Join(this.bookStoreDB.Book,
                Cart => Cart.BookId,
                Book => Book.BookID,
                (Cart, Book) =>
                new
                {
                    cartId = Cart.CartID,
                    bookId = Book.BookID,
                    bookTitle = Book.BookTitle,
                    authorName = Book.AuthorName,
                    bookImage = Book.BookImage,
                    bookPrice = Book.BookPrice,
                    numOfCopies = Cart.NumOfCopies
                });
            return result;
        }

        public Cart RemoveCartRL(int CartID)
        {
            Cart cart = bookStoreDB.Cart.Find(CartID);
            if (cart != null)
            {
                bookStoreDB.Cart.Remove(cart);
                bookStoreDB.SaveChanges();
            }
            return cart;
        }
        public int NumOfBookRL()
        {
            int count = bookStoreDB.Cart.Count<Cart>();
            return count;
        }
    }
}
