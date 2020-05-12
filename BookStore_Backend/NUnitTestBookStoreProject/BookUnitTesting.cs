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
        Book book = new Book();
        [Test]
        public void AddBookTestInController()
        {
            var service = new Mock<IManager>();
            var controller = new BookController(service.Object);

            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = true;
            var data = controller.AddBook(book);
            Assert.NotNull(data);

        }

        [Test]
        public void AddBookTestInManager()
        {
            var service = new Mock<IBook>();
            var manager = new ImpBookManager(service.Object);
            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = true;
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
            var service = new Mock<IBook>();
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
<<<<<<< HEAD

            Assert.Pass();

=======
            Assert.Pass();
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
        }
    }
}
