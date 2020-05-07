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
        private readonly IBook irepo;
        public ImpBookManager(IBook irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddBook(Book book)
        {
            return this.irepo.AddBook(book);
        }

        public IEnumerable<Book> GetAllBook()
        {
            return this.irepo.GetAllBook();
        }

        public string Image(IFormFile file, int id)
        {
            return irepo.Image(file, id);
        }
    }
}
