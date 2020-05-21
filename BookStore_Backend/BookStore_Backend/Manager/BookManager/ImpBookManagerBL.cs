using Microsoft.AspNetCore.Http;
using BookStoreCommonLayer;
using BookStoreRepositoryLayer.BookRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBussinessLayer.BookManager
{
    public class ImpBookManagerBL : IManagerBL
    {
        private readonly IBookRL irepo;
        public ImpBookManagerBL(IBookRL irepo)
        {
            this.irepo = irepo;
        }
        public Task<int> AddBook(Book book)
        {
            return this.irepo.AddBookRL(book);
        }

        public IEnumerable<Book> GetAllBook()
        {
            return this.irepo.GetAllBookRL();
        }

        public string Image(IFormFile file, int id)
        {
            return irepo.ImageRL(file, id);
        }
        public int GetNumOfBook()
        {
            return irepo.GetNumOfBookRL();
        }
    }
}
