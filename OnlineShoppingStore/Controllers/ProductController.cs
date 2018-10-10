using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using OnlineShoppingStore.Repository;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Concrete;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineShoppingStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {


        // GET: Product
        public ViewResult List(string category,int page)
        {
            int PageSize = 2;
            IProductRepository repository = new EFProductRepository();
            ProductPageViewModel model = new ProductPageViewModel
            {
                products = ( repository.Products
                                  .Where(p => category == (String)null || p.Category == category)
                                  .OrderBy(p => p.ProductId)
                                  .Skip((page - 1) * PageSize)
                                  .Take(PageSize)
                                  ),
                info = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = repository.Products.Where(p => p.Category == null || p.Category == category).Count(),
                    ItemsPerPage = PageSize,

                },
                currentCategory = category
            };
            
            return View(model);
                                  
                                
        }

    }
}
            
           
           //List<Product> products = new List<Product> {
           //     new Product {Name = "Football", Price = 23},
           //     new Product {Name = "Surf board", Price = 179},
           //     new Product {Name = "Running shoes", Price = 95}
           // };
           
    
