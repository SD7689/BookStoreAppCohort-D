using BookStore_Api.Controllers;
using Manager.BookManager;
using Model;
using NUnit.Framework;
using Repository;
using Repository.BookRepo;
using System.Threading.Tasks;

namespace NUnitTestBookStoreProject
{
    public class BookUnitTesting
    {
        private static Book book;
        private static readonly BookStoreDBContext bookStoreDB;
        readonly BookImp bookImp = new BookImp(bookStoreDB);
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
