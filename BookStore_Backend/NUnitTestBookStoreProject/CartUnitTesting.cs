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
        Cart cart = new Cart();
        [Test]
        public void AddABookToCart_WhenPassToBookCartController_ShouldAddPerticularBookToCart()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            cart.BookId =1;
            var data = controller.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void AddABookToCart_WhenPassToBookCartManager_ShouldAddPerticularBookToCart()
        {
            var service = new Mock<ICartRepo>();
            var manager = new ImpCartManager(service.Object);
            cart.BookId = 1;
            var data = manager.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveBookFromCartList_FromCartController_ShouldRemoveThePerticlarBook()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            var data = controller.RemoveCart(1);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveBookFromCartList_FromCartManager_ShouldRemoveThePerticlarBook()
        {
            var service = new Mock<ICartRepo>();
            var manager = new ImpCartManager(service.Object);
            var data = manager.RemoveCart(11);
            Assert.Null(data);
        }
        [Test]
        public void GetAllCart_WhenPasseToCartController_ShouldReturn_AllBookAddedToCart()
        {
            var service = new Mock<ICartManager>();
            var controller = new CartController(service.Object);
            var data = controller.GetCartValue();
            Assert.NotNull(data);
        }

        [Test]
        public void GetAllCart_WhenPasseToCartManager_ShouldReturn_AllBookAddedToCart()
        {
            var service = new Mock<ICartRepo>();
            var manager = new ImpCartManager(service.Object);
            var data = manager.GetAllCartValue();
            Assert.NotNull(data);
        }
    }
}
