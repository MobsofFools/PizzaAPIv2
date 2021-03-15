using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaAPIv2.Models
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeImgSrc { get; set; }
        public int? RecipePrice { get; set; }
    }
}
