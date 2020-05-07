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

        /// <summary>
        /// Add book detail
        /// </summary>
        /// <param name="book"></param>
        /// <returns> IActionResult. </returns>
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
        
        /// <summary>
        /// Get all Books details
        /// </summary>
        /// <returns> List of Book </returns>
        [Route("GetAllBook")]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            return this.manager.GetAllBook();
        }
        [Route("AddBookImage")]
        [HttpPost]
        public ActionResult AddBookImage(IFormFile file,int id)
        {
            var result = this.manager.Image(file, id);
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest();
        }
    }
}