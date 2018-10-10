using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI_CodeProject
{
    public static class WebApiConfig
    {
        public static HttpConfiguration configuration = new HttpConfiguration();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityWebApiActivator.Start();

            var cors = new EnableCorsAttribute("*", "*", "GET");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            configuration = config;
        }
    }
}
