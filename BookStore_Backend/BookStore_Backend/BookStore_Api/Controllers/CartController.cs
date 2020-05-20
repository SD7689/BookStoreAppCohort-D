using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.CartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICartManager manager;

        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            var result = await this.manager.AddToCart(cart);
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

        [Route("RemoveCart")]
        [HttpDelete]
        public IActionResult RemoveCart(int cartId)
        {
            var cartData = this.manager.RemoveCart(cartId);
            sender.Send("Remove book in cart");
            if (cartData != null)
            {
                return this.Ok(cartData);
            }
            return this.BadRequest();
        }
        [Route("GetCartValue")]
        [HttpGet]
        public IQueryable GetCartValue()
        {
            return this.manager.GetAllCartValue();
        }
        [Route("NumOfBook")]
        [HttpGet]
        public ActionResult BookCount()
        {
            var count=this.manager.NumOfBook();
            return this.Ok(count);
        }
    }
}