using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails details);
        
    }
}