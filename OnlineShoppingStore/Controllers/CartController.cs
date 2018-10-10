using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Concrete;


namespace OnlineShoppingStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel { cart = cart, returnUrl = returnUrl });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int ProductId, String returnUrl)
        {
            EFProductRepository repository = new EFProductRepository();
            Product product = repository.Products.FirstOrDefault(p => p.ProductId==ProductId);
            if (product != null)
            {
                cart.Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult CheckOut()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult CheckOut(Cart cart,ShippingDetails details)
        {
            if (cart.ReturnCart.Count() == 0)
            {
                ModelState.AddModelError("","Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                EmailOrderProcesssor processor = new EmailOrderProcesssor(new EmailSettings());
                processor.ProcessOrder(cart, details);
                return View("Successful");
            }
            else
            {
                return View();
            }
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public RedirectToRouteResult RemoveCart(Cart cart,int ProductId, String returnUrl)
        {
            EFProductRepository repository = new EFProductRepository();
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                cart.Remove(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        
    }
}