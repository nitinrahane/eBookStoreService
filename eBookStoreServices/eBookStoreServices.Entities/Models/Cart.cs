using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Entities.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public CartStaus CartStaus { get; set; }

    }

    public class CartItemDetails : Book{         
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }

    public enum CartStaus
    {
        AddedToCart,
        OrderCompleted
    }
}
