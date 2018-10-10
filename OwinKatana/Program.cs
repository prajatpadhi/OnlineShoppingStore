using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_CodeProject;

namespace OwinKatana
{
    using AppFunc = Func<IDictionary<string,object>,Task>;
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Starting");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
                
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //app.Use( async (e,n) => 
            //{
            //    foreach(var pair in e.Environment)
            //    {
            //        Console.WriteLine($"{pair.Key} +++++++++ {pair.Value}");
            //    }

            //    await n();
            //});


            ConfigureWebApi(app);
            app.UseHelloWorldComponent();
            //app.UseWelcomePage();
            //app.Run(ctx => ctx.Response.WriteAsync("Hello"));
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Yes", "api/{controller}/{id}",new { id=RouteParameter.Optional});
            app.UseWebApi(config);
        }
    }


    public static class AppbuilderExtensions
    {
        public static void UseHelloWorldComponent(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
            //app.UseWelcomePage();
            //app.Run(ctx => ctx.Response.WriteAsync("Hello"));
        }
    }



    public class HelloWorldComponent
    {
        private AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, Object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (StreamWriter writer=new StreamWriter(response))
            {
                return writer.WriteAsync("Hello World");
            }
            //app.UseWelcomePage();
            //app.Run(ctx => ctx.Response.WriteAsync("Hello"));
        }
    }
}
