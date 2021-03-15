using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaAPIv2.Models
{
    public partial class OrderedItem
    {
        public int OrderedItemId { get; set; }
        public int OrderId { get; set; }
        public int RecipeId { get; set; }
        public int Quantity { get; set; }
    }
}
