using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CodeProject.BusinessServices;

namespace WebAPI_CodeProject.Utilities
{
    public class Bootstrapper
    {
        
            public static void Init()
            {
                DependencyInjector.Register<IProductServices, ProductServices>();
            }
        
    }
}