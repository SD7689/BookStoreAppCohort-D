using BookStore_Api.Controllers;
using BookStoreBussinessLayer.BookManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;
using Moq;
using NUnit.Framework;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.BookRepo;
using System.Threading.Tasks;

namespace NUnitTestBookStoreProject
{
    public class BookUnitTesting
    {
        Book book = new Book();
        [Test]
        public void GivenBookDetail_ToController_ShouldReturnBookDetails()
        {
            var service = new Mock<IManagerBL>();
            var controller = new BookController(service.Object);

            book.BookTitle = "Never Happen Twice";
            book.AuthorName = "BDEC";
            book.BookImage = "images.jpg";
            book.BookPrice = 85.00;
            book.Availability = 10;
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
            book.Availability = 10;
            var data = manager.AddBookBL(book);
            Assert.NotNull(data);
        }

        [Test]
        public void BookStoreController_ShouldReturnAllBook()
        {
            var service = new Mock<IManagerBL>();
            var controller = new BookController(service.Object);
            var data = controller.GetAllBook();
            Assert.NotNull(data);
        }
        [Test]
        public void BookStoreBussinessLayer_ShouldReturnAllBook()
        {
            var service = new Mock<IBookRL>();
            var manager = new ImpBookManagerBL(service.Object);
            var data = manager.GetAllBookBL();
            Assert.NotNull(data);
        }

        [Test]
        public void BookStoreController_ShouldReturnNumOfBook()
        {
            var service = new Mock<IManagerBL>();
            var Controller = new BookController(service.Object);
            var actual = Controller.NumOfBooks();
            Assert.IsNotNull(actual);
        }

        [Test]
        public void Test_ImBookStoreController_ShouldReturnLinkOfImage()
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
