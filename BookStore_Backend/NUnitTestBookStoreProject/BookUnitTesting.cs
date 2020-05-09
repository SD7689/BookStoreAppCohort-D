using BookStore_Api.Controllers;
using Manager.BookManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using NUnit.Framework;
using Repository;
using Repository.BookRepo;
using System.Threading.Tasks;

namespace NUnitTestBookStoreProject
{
    public class BookUnitTesting
    {

        [Test]
        public void Test_GetNumber_Books()
        {
            var service = new Mock<IManager>();
            var Controller = new BookController(service.Object);
            var actual = Controller.NumOfBooks();
            Assert.IsNotNull(actual);
        }

        [Test]
        public void Test_ImageUpload()
        {

            IFormFile file=null;
            var service = new Mock<IManager>();
            var Controller = new BookController(service.Object);
            var actual = Controller.AddBookImage(file, 2);
            Assert.IsNotNull(actual);

            Assert.Pass();

        }
    }
}
