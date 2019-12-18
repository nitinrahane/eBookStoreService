using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Entities.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<Order_Item> Order_Items { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Completed
    }

    public class OrderHistroy: Order
    {
        public List<Book> bookDetailsForOrder { get; set; }
    }


}
