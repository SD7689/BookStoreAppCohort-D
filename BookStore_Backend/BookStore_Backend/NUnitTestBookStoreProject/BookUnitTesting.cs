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
        BookCL book = new BookCL();
        [Test]
        public void AddBookTestInController()
        {
            var service = new Mock<IManager>();
            var controller = new BookController(service.Object);

            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = 10;
            var data = controller.AddBooks(book);
            Assert.NotNull(data);

        }

        [Test]
        public void AddBookTestInManager()
        {
            var service = new Mock<IBookRL>();
            var manager = new ImpBookManager(service.Object);
            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = 10;
            var data = manager.AddBook(book);
            Assert.NotNull(data);
        }

        [Test]
        public void GetAllBookTestControler()
        {
            var service = new Mock<IManager>();
            var controller = new BookController(service.Object);
            var data = controller.GetAllBook();
            Assert.NotNull(data);
        }
        [Test]
        public void GetAllBookTestInManager()
        {
            var service = new Mock<IBookRL>();
            var manager = new ImpBookManager(service.Object);
            var data = manager.GetAllBook();
            Assert.NotNull(data);
        }

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
        }
    }
}
