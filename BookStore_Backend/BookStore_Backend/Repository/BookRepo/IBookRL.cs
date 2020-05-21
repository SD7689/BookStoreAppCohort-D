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
        Task<int> AddBookRL(Book book);
        IEnumerable<Book> GetAllBookRL();
        string ImageRL(IFormFile file, int id);
        int GetNumOfBookRL();
    }
}
