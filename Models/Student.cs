using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models
{
    public class Student : Person
    {
        public override DateTime DateOfBirth { get; set; }
    }
}