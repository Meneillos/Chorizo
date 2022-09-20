using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Validation;

namespace Chorizo.Models
{
    public class Teacher : Person
    {
        [MinimumAge(18)]
        public override DateTime DateOfBirth { get; set; }
    }
}