using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CartLine
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}