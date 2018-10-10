using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Repository;
using OnlineShoppingStore.Concrete;

namespace OnlineShoppingStore.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IProductRepository repository = new EFProductRepository();
            IEnumerable<string> categories = repository.Products.Select(p => p.Category)
                                              .Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}