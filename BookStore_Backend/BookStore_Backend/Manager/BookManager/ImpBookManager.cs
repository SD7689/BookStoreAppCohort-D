using Microsoft.AspNetCore.Http;
using Model;
using Repository.BookRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.BookManager
{
    public class ImpBookManager : IManager
    {
        private readonly IBookRL irepo;
        public ImpBookManager(IBookRL irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddBook(BookCL book)
        {
            return this.irepo.AddBook(book);
        }

        public IEnumerable<BookCL> GetAllBook()
        {
            return this.irepo.GetAllBook();
        }

        public string Image(IFormFile file, int id)
        {
            return irepo.Image(file, id);
        }
        public int GetNumOfBook()
        {
            return irepo.GetNumOfBook();
        }
    }
}
