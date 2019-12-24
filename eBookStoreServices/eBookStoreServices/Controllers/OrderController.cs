using eBookStoreServices.Entities.Models;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using eBookStoreServices.Services.Interfaces;

namespace eBookStoreServices.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private IOrderService _orderService;
        private ICartService _cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/order")]
        public IEnumerable<OrderHistroy> Get()
        {
            var userID = User.Identity.GetUserId();
            return _orderService.GetAllOrdersForUser(userID);
        }
       

        // POST api/<controller>
        [HttpPost]
        [Route("api/order")]
        public IHttpActionResult Post(IEnumerable<CartItemDetails> cartItems)
        {
            var userID = User.Identity.GetUserId();
            Order orderDetails = new Order();
            orderDetails.UserID = userID;
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
                bool result = _orderService.AddOrderDetails(orderDetails);
                if (result)
                {
                    foreach (var item in cartItems)
                    {
                        _cartService.DeleteItemFromCart(new CartItem()
                        {
                            BookID = item.ID,
                            UserID = userID
                        });
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }
   
    }
}