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
    [Authorize(Roles = "Administrator")]
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
            var result = await this.manager.AddBook(book);
            sender.Send("Add the book details");
            if (result == 1)
            {
                return this.Ok(book);
            }
            return this.BadRequest("");
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
        public ActionResult AddBookImage(IFormFile file,int id)
        {
            var result = this.manager.Image(file, id);
            sender.Send("Image Uploaded ");
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest(ErrorMessage());
        }

        [Route("GetNumber_Books")]
        [HttpGet]
        public ActionResult NumOfBooks()
        {
            var count = manager.GetNumOfBook();
            sender.Send("Count the number of books");
            if (count >0)
            {
                return this.Ok(count);
            }
            return this.BadRequest(ErrorMessage());
        }

        public static JsonErrorModel ErrorMessage()
        {
            if (HttpStatusCode.InternalServerError.Equals(400))
            {
                var error = new JsonErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = "Invalid data enter"
                };

                return error;
            }
            else if (HttpStatusCode.InternalServerError.Equals(500))
            {
                var error = new JsonErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = "Internal server error "
                };

                return error;
            }

            return null;
        }

    }
}