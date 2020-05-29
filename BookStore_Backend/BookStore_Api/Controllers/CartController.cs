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
        private readonly ICartManagerBL manager;

        public CartController(ICartManagerBL manager)
        {
            this.manager = manager;
        }
          /// <summary>
          ///  it adds the book details
          /// </summary>
          /// <param name="cart"></param>
          /// <returns></returns>
        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartCL cart)
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
          /// <summary>
          /// It remove the particular cart
          /// </summary>
          /// <param name="cartId"></param>
          /// <returns></returns>
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
        /// <summary>
        ///  It return the all card details
        /// </summary>
        /// <returns></returns>
        [Route("GetCartValue")]
        [HttpGet]
        public IQueryable GetCartValue()
        {
            return this.manager.GetAllCartValue();
        }
        /// <summary>
        /// It returns the book count in cart
        /// </summary>
        /// <returns></returns>
        [Route("NumOfBook")]
        [HttpGet]
        public ActionResult BookCount()
        {
            var count=this.manager.NumOfBook();
            return this.Ok(count);
        }
    }
}