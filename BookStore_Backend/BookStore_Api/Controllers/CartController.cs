using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.CartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager manager;

        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddBook(Cart cart)
        {
            var result = await this.manager.AddToCart(cart);
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
            if (cartData != null)
            {
                return this.Ok(cartData);
            }
            return this.BadRequest();
        }
    }
}