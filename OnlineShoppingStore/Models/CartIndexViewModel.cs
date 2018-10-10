using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string  returnUrl { get; set; }
    }
}