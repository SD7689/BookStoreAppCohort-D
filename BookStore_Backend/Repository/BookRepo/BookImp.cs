using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Repository.BookRepo
{
    public class BookImp : IBook
    {
        private readonly BookStoreDBContext bookStoreDB;

        public BookImp(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }
        public Task<int> AddBook(Book book)
        {
            bookStoreDB.Book.Add(book);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public IEnumerable<Book> GetAllBook()
        {
            return bookStoreDB.Book;
        }
       
    }
}
