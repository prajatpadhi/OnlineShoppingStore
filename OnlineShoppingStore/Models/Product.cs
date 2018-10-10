using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShoppingStore.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage="Please enter a valid description")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [Required(ErrorMessage = "Please enter the price")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Please enter the price")]
        public Decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter the Category")]
        public String Category { get; set; }
        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }
    }
}