using Microsoft.AspNetCore.Http;
using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.BookRepo
{
    public interface IBookRL
    {
        Task<int> AddBook(Book book);
        IEnumerable<Book> GetAllBook();
        string Image(IFormFile file, int id);
        int GetNumOfBook();
    }
}
