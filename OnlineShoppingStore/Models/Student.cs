using OnlineShoppingStore.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        public string FirstName { get; set; } 
        public String LastName { get; set; }
    }
}