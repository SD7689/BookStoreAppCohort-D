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
        public void GivenBookDetail_ToController_ShouldReturnBookDetails()
        {
            var service = new Mock<IManagerBL>();
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
        public void GivenBookDetail_ToBookStoreBusinesLayer_ShouldReturnBookDetails()
        {
            var service = new Mock<IBookRL>();
            var manager = new ImpBookManagerBL(service.Object);
            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = true;
            var data = manager.AddBook(book);
            Assert.NotNull(data);
        }

        [Test]
        public void GivenBookDetail_ToBookController_ShouldReturnAllBookDetails( )
        {
            var service = new Mock<IManagerBL>();
            var controller = new BookController(service.Object);
            var data = controller.GetAllBook();
            Assert.NotNull(data);
        }
        [Test]
        public void GvenBookDetail_ToBookBusinessLayer_ShouldReturnAllBooksDetails()
        {
            var service = new Mock<IBookRL>();
            var manager = new ImpBookManagerBL(service.Object);
            var data = manager.GetAllBook();
            Assert.NotNull(data);
        }

        [Test]
        public void GivenBookDetail_ToBookController_ShouldReturnBookCounts()
        {
            var service = new Mock<IManagerBL>();
            var Controller = new BookController(service.Object);
            var actual = Controller.NumOfBooks();
            Assert.IsNotNull(actual);
        }

        [Test]
        public void Test_ImageUpload()
        {
            IFormFile file=null;
            var service = new Mock<IManagerBL>();
            var Controller = new BookController(service.Object);
            var actual = Controller.AddBookImage(file, 2);
            Assert.IsNotNull(actual);
            Assert.Pass();
        }
    }
}
