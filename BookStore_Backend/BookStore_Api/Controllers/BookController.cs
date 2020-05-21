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
        private readonly Sender sender = new Sender();
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
        [Route("Its Api add the book data")]
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var result = await this.manager.AddBook(book);
            sender.Send("Add the book details");
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
        [Route("Its show the all book data")]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            sender.Send("Get all books details");
            return this.manager.GetAllBook();
        }

        [Route(" Its add the book image")]
        [HttpPost]
        public ActionResult AddBookImage(IFormFile file,int id)
        {
            var result = this.manager.Image(file, id);
            sender.Send("Image Uploaded ");
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [Route("Its show the number of books ")]
        [HttpGet]
        public ActionResult NumOfBooks()
        {
            var count = manager.GetNumOfBook();
            sender.Send("Count the number of books");
            if (count >0)
            {
                return this.Ok(count);
            }
            return this.BadRequest();
        }

    }
}