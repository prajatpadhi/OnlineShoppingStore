using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using OnlineShoppingStore.Concrete;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.App_Start
{
    public class IdentityConfig
    {
        public void Configuration (IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new EFDbContext());
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
                new RoleManager<ApplicationRole>(
                    new RoleStore<ApplicationRole>(context.Get<EFDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

    }

    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string role) : base(role) { }
    }

    public class ApplicationUserManager: UserManager<ApplicationUser>
    {
        public ApplicationUserManager(UserStore<ApplicationUser> store) : base(store) { }

        public static ApplicationUserManager Create(
       IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(context.Get<EFDbContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }

   

}