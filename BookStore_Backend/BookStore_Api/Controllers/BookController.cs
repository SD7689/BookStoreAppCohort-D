using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Manager.BookManager;
using Microsoft.AspNetCore.Authorization;
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
        //[Route(" Book ")]
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            try
            {
                var result = await this.manager.AddBook(book);
                sender.Send("Add the book details");
                return this.Ok(book);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Result = "Internal srever error" });
            }
        }

        /// <summary>
        /// Get all Books details
        /// </summary>
        /// <returns> List of Book </returns>
        // [Route("Its show the all book data")]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            sender.Send("Get all books details");
            return this.manager.GetAllBook();
        }

        [Route("AddBookImage")]
        [HttpPost]
        public ActionResult AddBookImage(IFormFile file, int id)
        {
            try
            {
                var result = this.manager.Image(file, id);
                sender.Send("Image Uploaded ");
                return this.Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Result = "Internal srever error" });
            }
        }

        [Route("GetNumber_Books")]
        [HttpGet]
        public ActionResult NumOfBooks()
        {
            var count = manager.GetNumOfBook();
            sender.Send("Count the number of books");
            if (count > 0)
            {
                return this.Ok(count);
            }
            return StatusCode(400, new { Result = "Book table is empty" });
        }


    }
}