using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIv2.Models
{
    public class OrderItemInfo
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int Quantity { get; set; }
        public string RecipeImgSrc { get; set; }

    }
}
