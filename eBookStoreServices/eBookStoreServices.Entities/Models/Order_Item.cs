using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Entities.Models
{
    public class Order_Item
    {        
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
    }
}
