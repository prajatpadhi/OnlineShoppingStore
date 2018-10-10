using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public interface IAuthentication
    {
        bool Authenticate(string UserName, string Password);
        

    }
}