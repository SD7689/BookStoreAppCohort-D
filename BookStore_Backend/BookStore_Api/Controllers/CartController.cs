using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.CartManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly Sender sender = new Sender();
        private readonly ICartManager manager;

        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        //[Route(" Cart ")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            try
            {
                var result = await this.manager.AddToCart(cart);
                sender.Send("Add book in cart");
                return this.Ok(cart);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Result = "Internal srever error" });
            }

        }

        //[Route("R")]
        [HttpDelete]
        public IActionResult RemoveCart(int cartId)
        {
            var cartData = this.manager.RemoveCart(cartId);
            sender.Send("Remove book in cart");
            if (cartData != null)
                return this.Ok(cartData);

            return StatusCode(400, new { Result = "This Id is not presence in database" });
        }

        //[Route("Its show the cart data ")]
        [HttpGet]
        public IQueryable GetCartValue()
        {
            return this.manager.GetAllCartValue();
        }

        [Route("GetBookNumber")]
        [HttpGet]
        public IActionResult BookCount()
        {
            var count=this.manager.NumOfBook();
            return this.Ok(count);
        }
    }
}