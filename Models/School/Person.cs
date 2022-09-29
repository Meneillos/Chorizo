using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Validation;

namespace Chorizo.Models.School
{
    public class Person
    {
        private string? _name;
        private string? _surename;

        [Key]
        public int PersonId { get; set; }
        [Required]
        public string? Name { get => _name; set => _name = value!.ToLower(); }
        [Required]
        public string? Surename { get => _surename; set => _surename = value!.ToLower(); }
        [Required]
        [DateOfBirthValidation]
        public DateTime DateOfBirth { get; set; }
        public int Age { get => (DateTime.Today - DateOfBirth).Days / 365; }
    }
}