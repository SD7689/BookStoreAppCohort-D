using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.BookManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;
using Microsoft.AspNetCore.Authorization;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly IManagerBL manager;

        public BookController(IManagerBL manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Add book detail
        /// </summary>
        /// <param name="book"></param>
        /// <returns> IActionResult. </returns>
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var result = await this.manager.AddBookBL(book);
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
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            sender.Send("Get all books details");
            return this.manager.GetAllBookBL();
        }
        [Route("AddBookImage")]
        [HttpPost]
        public ActionResult UploadImage(IFormFile file,int id)
        {
            var result = this.manager.ImageBL(file, id);
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest();
        }
        [Route("NumOfBooks")]
        [HttpGet]
        public ActionResult NumOfBooks()
        {
            var count = manager.GetNumOfBookBL();
            if (count >0)
            {
                return this.Ok(count);
            }
            return this.BadRequest();
        }

    }
}