using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Validation
{
    public class DateOfBirthValidation : ValidationAttribute
    {
        public string GetErrorMessage() => "The date of birth cannot be later than the present date";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((DateTime)value! > DateTime.Today) return new ValidationResult(GetErrorMessage());
            return ValidationResult.Success;
        }
    }
}