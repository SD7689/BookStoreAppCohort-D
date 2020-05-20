using Microsoft.AspNetCore.Http;
using BookStoreCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.BookManager
{
   public interface IManagerBL
    {
        Task<int> AddBook(Book book);
        IEnumerable<Book> GetAllBook();
        string Image(IFormFile file, int id);
        int GetNumOfBook();
       
    }
}
