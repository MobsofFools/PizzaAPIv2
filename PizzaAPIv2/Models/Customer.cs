using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaAPIv2.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPostal { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerEmail { get; set; }
    }
}
