using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ProductPageViewModel
    {
        public IEnumerable<Product> products { get; set;  }
        public PagingInfo info { get; set; }
        public string currentCategory { get; set; }
    }
}