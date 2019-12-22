using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using eBookStoreServices.Services.Interfaces;

namespace eBookStoreServices.Controllers
{
    [Authorize]
    public class CartController : ApiController
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        // GET api/<controller>/5
        [HttpGet]
        public IEnumerable<CartItemDetails> Get()
        {
            return _cartService.GetCartItems(User.Identity.GetUserId());
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(CartItem cartItem)
        {
            CartItem item = new CartItem()
            {
                BookID = cartItem.BookID,
                UserID = User.Identity.GetUserId()
            };
            bool result = _cartService.AddItemToCart(item);
            if (result)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(CartItem cartItem)
        {
            bool result = _cartService.UpdateItemQuantity(cartItem);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
            
        }

        // DELETE api/<controller>/5            
        public IHttpActionResult Delete(int id)
        {          

            CartItem cartItem = new CartItem()
            {
                UserID = User.Identity.GetUserId(),
                BookID = id
            };
            bool result = _cartService.DeleteItemFromCart(cartItem);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}