using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models.School
{
    public class Subject
    {
        public Subject()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        private string? _name;
        private string? _description;

        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string? Name { get => _name; set => _name = value!.ToLower(); }
        public string? Description { get => _description; set => _description = value!.ToLower(); }
        public int Course { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}