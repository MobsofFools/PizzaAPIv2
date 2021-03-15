using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIv2.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerEmail { get; set; }
        public decimal? Total { get; set; }
        public string OrderStatus { get; set; }
    }
}
