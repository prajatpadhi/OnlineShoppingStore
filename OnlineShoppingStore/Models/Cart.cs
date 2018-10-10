using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class Cart
    {
        private List<CartLine> totalCart = new List<CartLine>();

        public void Add(Product product, int quantity)
        {
            CartLine present = totalCart.Where(p => p.product.ProductId == product.ProductId).FirstOrDefault();
            if (present == null)
            {
                totalCart.Add(new CartLine { product = product, Quantity = quantity });
            }
            else
            {
                present.Quantity += quantity;
            }
        }

        public void Remove(Product product)
        {
            totalCart.RemoveAll(p => p.product == product);
        }

        public decimal ComputeTotalPrice()
        {
            decimal totalPrice = totalCart.Sum(p => p.product.Price * p.Quantity);
            return totalPrice;
        }

        public IEnumerable<CartLine> ReturnCart
        {
            get { return totalCart; }
        }

        public void Clear()
        {
            totalCart.Clear();
        }
    }
}