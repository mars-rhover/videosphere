using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ShoppingCart
    {
        public List<Movie> Items { get; set; } = new List<Movie>();
    }

}
