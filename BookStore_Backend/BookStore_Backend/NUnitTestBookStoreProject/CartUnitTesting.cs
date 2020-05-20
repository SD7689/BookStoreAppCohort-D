using BookStore_Api.Controllers;
using BookStoreBussinessLayer.CartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;
using Moq;
using NUnit.Framework;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.CartRepo;
using System.Threading.Tasks;

namespace NUnitTestBookStoreProject
{
   public class CartUnitTesting
    {
        Cart cart = new Cart();
        [Test]
        public void GivenCartDetail_CartController_ShouldReturnCartValue()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            cart.BookId =1;
            var data = controller.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void GivenCartDetail_CartBL_ShouldReturnCartValue()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManagerBL(service.Object);
            cart.BookId = 1;
            var data = manager.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartValue_CartController_ShouldReturnCartValue()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            var data = controller.RemoveCart(1);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartValue_CartBL_ShouldReturnCartValue()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManagerBL(service.Object);
            var data = manager.RemoveCart(11);
            Assert.Null(data);
        }
        [Test]
        public void AllCartValue_CartController_ShouldReturnAllCartValue()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            var data = controller.GetCartValue();
            Assert.NotNull(data);
        }

        [Test]
        public void AllCartValue_CartBL_ShouldReturnAllCartValue()
        {
            var service = new Mock<ICartRepoRL>();
            var manager = new ImpCartManagerBL(service.Object);
            var data = manager.GetAllCartValue();
            Assert.NotNull(data);
        }
    }
}
