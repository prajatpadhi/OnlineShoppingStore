using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using OnlineShoppingStore.Concrete;


namespace OnlineShoppingStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository = new EFProductRepository();
        
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int ProductId)
        {
            return View(repository.Products.FirstOrDefault(p => p.ProductId == ProductId));

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["Message"] = "Your changes have been saved successfully";
                return RedirectToAction("Index");
            }

            else return View();
        }

        public ViewResult Create()
        {
            return View(new Product());

        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["Message"] = "Your changes have been saved successfully";
                return RedirectToAction("Index");
            }

            else return View();
        }

        public ActionResult Delete(int ProductId)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteProduct(ProductId);
                TempData["Message"] = "Your changes have been saved successfully";
                
            }

            else
            {
                TempData["Message"] = "There were some issues in deleting the product ";
                
            }
            return RedirectToAction("Index");
        }
    }
}