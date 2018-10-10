using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(50,MinimumLength =6,ErrorMessage ="Please enter password between 6 and 50 letters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Boolean RememberMe { get; set; }

    }
}