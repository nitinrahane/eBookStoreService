using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Services.Interfaces
{
    public interface IOrderService
    {
        bool AddOrderDetails(Order orderDetails);
        List<OrderHistroy> GetAllOrdersForUser(string userId);
    }
}
