using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Entities.Models
{
    public class Book
    {
        public int ID { get; set; }      

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public int? PublishedYear { get; set; }

        public decimal? Price { get; set; }
    }
}
