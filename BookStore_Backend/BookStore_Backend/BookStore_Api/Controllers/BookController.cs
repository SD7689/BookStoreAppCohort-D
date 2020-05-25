﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("AddBooks")]
        [HttpPost]
        public async Task<IActionResult> AddBooks(BookCL book)
        {
            var result = await this.manager.AddBook(book);
            sender.Send("Add the book details");
            if (result == 1)
            {
                return this.Ok(book);
            }

            return this.BadRequest(new { error="wrong input given"});
        }
        
        /// <summary>
        /// Get all Books details
        /// </summary>
        /// <returns> List of Book </returns>
        [Route("GetAllBooks")]
        [HttpGet]
        public IEnumerable<BookCL> GetAllBook()
        {
            sender.Send("Get all books details");
            return this.manager.GetAllBook();
        }
        [Route("UploadBookImage")]
        [HttpPost]
        public ActionResult AddBookImage(IFormFile file,int id)
        {
            var result = this.manager.Image(file, id);
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest(new { error = "wrong input given" });
        }
        [Route("CountNumOfBooks")]
        [HttpGet]
        public ActionResult NumOfBooks()
        {
            var count = manager.GetNumOfBook();
            if (count >0)
            {
                return this.Ok(count);
            }
            return this.BadRequest(new { error = "there is no any one book" });
        }

    }
}