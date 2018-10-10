using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Concrete
{
    public class Authentication : IAuthentication
    {
        EFDbContext context = new EFDbContext();
        public  bool Authenticate(string UserName, string Password)
        {
            if (context.login.SingleOrDefault(p => p.UserName == UserName && p.Password == Password) != null)
                return true;
            else return false;
        }


    }

}