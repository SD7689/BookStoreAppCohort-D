using BookStore_Api.Controllers;
using Manager.CartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using NUnit.Framework;
using Repository;
using Repository.CartRepo;
using System.Threading.Tasks;

namespace NUnitTestBookStoreProject
{
   public class CartUnitTesting
    {
        CartCL cart = new CartCL();
        [Test]
        public void AddToCartTestInController()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            cart.BookId =1;
            var data = controller.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void AddToCartTestInManager()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManager(service.Object);
            cart.BookId = 1;
            var data = manager.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartTestInController()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            var data = controller.RemoveCart(1);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartTestInManager()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManager(service.Object);
            var data = manager.RemoveCart(11);
            Assert.Null(data);
        }
        [Test]
        public void GetAllCartTestInController()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            var data = controller.GetCartValue();
            Assert.NotNull(data);
        }

        [Test]
        public void GetAllCartTestInManager()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManager(service.Object);
            var data = manager.GetAllCartValue();
            Assert.NotNull(data);
        }
    }
}
