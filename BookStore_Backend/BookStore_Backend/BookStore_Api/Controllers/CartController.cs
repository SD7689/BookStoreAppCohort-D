using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.CartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreCommonLayer;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICartManagerBL manager;

        public CartController(ICartManagerBL manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            var result = await this.manager.AddToCartBL(cart);
            sender.Send("Add book in cart");
            if (result == 1)
            {
                return this.Ok(cart);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult RemoveCart(int cartId)
        {
            var cartData = this.manager.RemoveCartBL(cartId);
            sender.Send("Remove book in cart");
            if (cartData != null)
            {
                return this.Ok(cartData);
            }
            return this.BadRequest();
        }
        [HttpGet]
        public IQueryable GetCartValue()
        {
            return this.manager.GetAllCartValueBL();
        }
        [Route("NumOfBook")]
        [HttpGet]
        public ActionResult BookCount()
        {
            var count=this.manager.NumOfBookBL();
            return this.Ok(count);
        }
    }
}