using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OnlineShoppingStore.Attributes
{
    public class MaxWords : ValidationAttribute
    {
        private readonly int _maxwords;
        public MaxWords(int maxwords):base("{0} has too many letters")
        {
            _maxwords = maxwords;
        }

        protected override ValidationResult IsValid(object value,ValidationContext context)
        {
            if (value != null)
            {
                String address = value.ToString();
                if (address.Length > _maxwords)
                {
                    string errormessage = FormatErrorMessage(context.DisplayName);
                    return new ValidationResult(errormessage);
                }

                return ValidationResult.Success;
            }

            else return new ValidationResult("null value");
            
        }
    }
}