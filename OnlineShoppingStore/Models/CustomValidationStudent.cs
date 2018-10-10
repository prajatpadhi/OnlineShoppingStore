using OnlineShoppingStore.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OnlineShoppingStore.Models
{
    public class CustomValidationStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public long RollNo { get; set; }
        [MaxWords(10)]
        public String Address1 { get; set; }
        [MaxWords(10,ErrorMessage="Address2 has too many letters")]
        public String Address2 { get; set; }


    }
}