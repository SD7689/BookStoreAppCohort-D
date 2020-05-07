﻿using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BookRepo
{
    public interface IBook
    {
        Task<int> AddBook(Book book);
        IEnumerable<Book> GetAllBook();
        string Image(IFormFile file, int id);
    }
}
