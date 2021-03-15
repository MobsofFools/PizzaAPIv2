using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaAPIv2.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Total { get; set; }
        public string OrderStatus { get; set; }
    }
}
