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
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public bool AddOrderDetails(Order orderDetails)
        {
            return this._orderRepo.AddOrderDetails(orderDetails);
        }

        public List<OrderHistroy> GetAllOrdersForUser(string userId)
        {
            return this._orderRepo.GetAllOrdersForUser(userId);
        }
    }
}
