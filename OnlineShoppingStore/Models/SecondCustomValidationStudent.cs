using OnlineShoppingStore.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class SecondCustomValidationStudent : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public long RollNo { get; set; }
        
        public String Address1 { get; set; }
        
        public String Address2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Address1.Length > 10)
            {
                yield return new ValidationResult("Address1 has too many letters",new [] { "Address1"});
               
            }

            if (Address2.Length > 10)
            {
                yield return new ValidationResult("Address2 has too many letters", new [] {"Address2" });
            }
        }
    }
}