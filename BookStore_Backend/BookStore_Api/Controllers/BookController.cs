using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.BookManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IManager manager;

        public BookController(IManager manager)
        {
            this.manager = manager;
        }
        [Route("AddBook")]
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var result = await this.manager.AddBook(book);
            if (result == 1)
            {
                return this.Ok(book);
            }

            return this.BadRequest();
        }


        [Route("GetAllBook")]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            return this.manager.GetAllBook();
        }
    }
}