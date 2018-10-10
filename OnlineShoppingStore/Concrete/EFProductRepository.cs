using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        
        public IEnumerable<Product> Products
        {
            get { return context.products; }

        }

        

        public Product DeleteProduct(int productId)
        {
           
            Product dbEntry = context.products.Find(productId);
            if (dbEntry != null)
            {
                context.products.Remove(dbEntry);
                context.SaveChanges();

            }
            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.products.Add(product);
            }
            else
            {
                Product dbEntry = context.products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                }
            }

            context.SaveChanges();
            
        }
    }
}