using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Data.Interfaces
{
    public interface IOrderRepository
    {
        bool AddOrderDetails(Order orderDetails);
        List<OrderHistroy> GetAllOrdersForUser(int userId);        
    }
}
