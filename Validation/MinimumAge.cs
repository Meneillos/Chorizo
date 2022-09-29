using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Validation
{
    public class MinimumAge : ValidationAttribute
    {
        private int _age;

        public MinimumAge(int age)
        {
            _age = age;
        }

        public string GetErrorMessage() => $"Age must be at least {_age} year old";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Test to access another property of the object.
            var propertyValue = validationContext.ObjectType.GetProperty("Name")!.GetValue(validationContext.ObjectInstance);
            Debug.WriteLine(_age);
            
            if ((DateTime.Today - (DateTime)value!).Days < _age * 365) return new ValidationResult(GetErrorMessage());
            return ValidationResult.Success;
        }
    }
}