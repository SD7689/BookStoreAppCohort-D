using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.BookManager
{
   public interface IManager
    {
        Task<int> AddBook(BookCL book);
        IEnumerable<BookCL> GetAllBook();
        string Image(IFormFile file, int id);
        int GetNumOfBook();
       
    }
}
