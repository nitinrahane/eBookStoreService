﻿using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Data.Interfaces
{
    public interface ICartRepository
    {
        bool AddItemToCart(CartItem item);
        bool UpdateItemQuantity(CartItem item);
        List<CartItemDetails> GetCartItems(string userID);
        bool DeleteItemFromCart(CartItem item);
    }
}
