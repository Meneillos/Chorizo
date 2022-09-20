using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Validation;

namespace Chorizo.Models
{
    public abstract class Person
    {
        public string? Name { get; set; }

        public string? Surename { get; set; }

        [DateOfBirthValidation]
        public virtual DateTime DateOfBirth { get; set; }

        public string? Nationality { get; set; }

        public int GetAge()
        {
            return (DateTime.Today - DateOfBirth).Days;
        }
    }
}