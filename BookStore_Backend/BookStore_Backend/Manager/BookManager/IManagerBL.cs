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
        Task<int> AddBookBL(Book book);
        IEnumerable<Book> GetAllBookBL();
        string ImageBL(IFormFile file, int id);
        int GetNumOfBookBL();
       
    }
}
