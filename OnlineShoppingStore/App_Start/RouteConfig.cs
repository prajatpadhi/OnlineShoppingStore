using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShoppingStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Product", action = "List", page = 1 }
            );


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{page}/{category}",
               defaults: new { controller = "Product", action = "List", page = 1, category = (string)null }
           );


            routes.MapRoute(
                name: "yes",
                url: "{controller}/{action}",
                defaults: new { controller = "Others", action = "Index" }
            );

        }
    }
}
