using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Services.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepo;  

        public CartService(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public bool AddItemToCart(CartItem item)
        {
            return _cartRepo.AddItemToCart(item);
        }

        public bool DeleteItemFromCart(CartItem item)
        {
            return _cartRepo.DeleteItemFromCart(item);
        }

        public List<CartItemDetails> GetCartItems(string userID)
        {
            return _cartRepo.GetCartItems(userID);
        }

        public bool UpdateItemQuantity(CartItem item)
        {
            return _cartRepo.UpdateItemQuantity(item);
        }
    }
}
