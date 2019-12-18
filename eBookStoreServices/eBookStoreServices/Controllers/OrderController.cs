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
    public class OrderController : ApiController
    {
        private IOrderRepository order;
        private ICartRepository cartRepo;
        public OrderController(IOrderRepository _order, ICartRepository _cartRepo)
        {
            order = _order;
            cartRepo = _cartRepo;
        }

        // GET api/<controller>
        public IEnumerable<OrderHistroy> Get(int id)
        {
            return order.GetAllOrdersForUser(id);
        }
       

        // POST api/<controller>
        [HttpPost]
        [Route("api/order/user/{userId}")]
        public IHttpActionResult Post(int userId, IEnumerable<CartItemDetails> cartItems)
        {
            Order orderDetails = new Order();
            orderDetails.UserID = userId;
            orderDetails.Order_Items = new List<Order_Item>();
            foreach (var item in cartItems)
            {
                orderDetails.Order_Items.Add(new Order_Item
                {
                    BookID = item.ID,
                    Quantity = item.Quantity
                });
                orderDetails.TotalPrice = orderDetails.TotalPrice + (decimal)(item.Quantity * item.Price);
            }
            if (orderDetails.Order_Items.Count > 0)
            {
                bool result = order.AddOrderDetails(orderDetails);
                if (result)
                {
                    foreach (var item in cartItems)
                    {
                        cartRepo.DeleteItemFromCart(new CartItem()
                        {
                            BookID = item.ID,
                            UserID = userId
                        });
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }
   
    }
}