using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class LoginViewModel
    {
        public LoginModel login { get; set; }
        public string returnUrl { get; set; }
    }
}