using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eBookStoreServices.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository carts;
        public CartController(ICartRepository _carts)
        {
            carts = _carts;
        }

        [HttpGet]
        // GET api/<controller>/5
        public IEnumerable<CartItemDetails> Get(int id)
        {
            return carts.GetCartItems(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(CartItem item)
        {
            bool result = carts.AddItemToCart(item);
            if (result)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(CartItem cartItem)
        {
            bool result = carts.UpdateItemQuantity(cartItem);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
            
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/cart/user/{userID}/book/{bookID}")]
        public IHttpActionResult Delete(int userID, int bookID)
        {
            CartItem cartItem = new CartItem()
            {
                UserID = userID,
                BookID = bookID
            };
            bool result = carts.DeleteItemFromCart(cartItem);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}