using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinKatana
{
    public class GreetingController:ApiController
    {
        public Greeting Get()
        {
            return new Greeting { GreetingName = "ghqebxuidgfxuygxxgbccui" };
        }
    }
}
