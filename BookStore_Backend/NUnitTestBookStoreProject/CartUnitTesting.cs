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
        public void GivenCartDetail_ToCartController_ShouldReturnCartDetails()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            cart.BookId =1;
            var data = controller.AddToCart(cart);
            Assert.NotNull(data);
        }                          
        [Test]
        public void GivenCartDetail_ToCartBusinessLayer_ShouldReturnCartDetails()
        {
            var service = new Mock<ICartRL>();
            var manager = new ImpCartManagerBL(service.Object);
            cart.BookId = 1;
            var data = manager.AddToCart(cart);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartValue_CartController_ShouldReturnCartDetail()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            var data = controller.RemoveCart(1);
            Assert.NotNull(data);
        }
        [Test]
        public void RemoveCartDetails_CartBusinessLayer_ShouldReturnCartDetail()
        {
            var service = new Mock<ICartRL>();
            var manager = new ImpCartManagerBL(service.Object);
            var data = manager.RemoveCart(11);
            Assert.Null(data);
        }
        [Test]            
        public void GivenCartDetail_ToCartController_ShouldReturnAllCartDeatils()
        {
            var service = new Mock<ICartManagerBL>();
            var controller = new CartController(service.Object);
            var data = controller.GetCartValue();
            Assert.NotNull(data);
        }

        [Test]
        public void GivenCartDetail_ToCartBusinessReturnAllCartDeatils()
        {
            var service = new Mock<ICartRL>();
            var manager = new ImpCartManagerBL(service.Object);
            var data = manager.GetAllCartValue();
            Assert.NotNull(data);
        }
    }
}
