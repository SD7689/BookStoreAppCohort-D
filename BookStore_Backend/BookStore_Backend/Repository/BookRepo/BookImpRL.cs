﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Repository.BookRepo
{
    public class BookImpRL : IBookRL
    {
        private readonly BookStoreDBContext bookStoreDB;
        private readonly IConfiguration configuration;
        public BookImpRL(BookStoreDBContext bookStoreDB)
        {
            this.bookStoreDB = bookStoreDB;
        }
        public Task<int> AddBook(BookCL book)
        {
            bookStoreDB.Book.Add(book);
            var result = bookStoreDB.SaveChangesAsync();
            return result;
        }

        public IEnumerable<BookCL> GetAllBook()
        {
            return bookStoreDB.Book;
        }

        public string Image(IFormFile file, int id)
        {
            if (file == null)
            {
                return "Empty";
            }
            var stream = file.OpenReadStream();
            var name = file.FileName;
            Account account = new Account(configuration["Cloudinary:CloudName"], configuration["Cloudinary:APIKey"], configuration["Cloudinary:APISecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
             };
            ImageUploadResult UploadResult = cloudinary.Upload(uploadParams);
            cloudinary.Api.ApiUrlImgUp.BuildUrl(String.Format("{0}.{1}", UploadResult.PublicId, UploadResult.Format));
            var data = this.bookStoreDB.Book.Where(t => t.BookID == id).FirstOrDefault();
            data.BookImage = UploadResult.Uri.ToString();
            try
            {
                var result = this.bookStoreDB.SaveChanges();
                return data.BookImage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public int GetNumOfBook()
        {
            var NumOfBook=bookStoreDB.Book.Count<BookCL>();
            return NumOfBook;
        }
    }
}
