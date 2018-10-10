using OnlineShoppingStore.Concrete;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShoppingStore.App_Start;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //IAuthentication authentication = new Authentication();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel login,string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
            //    if (authentication.Authenticate(login.UserName, login.Password))
            //    {
            //        FormsAuthentication.SetAuthCookie(login.UserName,login.RememberMe);
            //        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("","Please enter correct username or password");

            //        return View();
            //    }
            //

            if (ModelState.IsValid)
            {
                PasswordHasher hasher = new PasswordHasher();
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                EFDbContext econtext = new EFDbContext();
                
                ApplicationUser user = await userManager.FindAsync(login.UserName, login.Password);
                if (user != null)
                {
                    var identity = userManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie).Result;
                    authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                    { IsPersistent=true},identity);
                    return Redirect(returnUrl?? Url.Action("Others"));

                }
                ModelState.AddModelError("ye", "username and password doesn't match");
                return View();

            }

            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}