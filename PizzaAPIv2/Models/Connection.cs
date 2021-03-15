using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIv2.Models
{
    public class Connection
    {
        public string Id { get; set; }
        public string ConnectionId { get; set; }
        public bool InProgress { get; set; }
    }
}
