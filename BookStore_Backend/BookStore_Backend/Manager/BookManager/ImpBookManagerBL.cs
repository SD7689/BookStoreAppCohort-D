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
        public Task<int> AddBookBL(Book book)
        {
            return this.irepo.AddBookRL(book);
        }

        public IEnumerable<Book> GetAllBookBL()
        {
            return this.irepo.GetAllBookRL();
        }

        public string ImageBL(IFormFile file, int id)
        {
            return irepo.ImageRL(file, id);
        }
        public int GetNumOfBookBL()
        {
            return irepo.GetNumOfBookRL();
        }
    }
}
