using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models.School
{

    public class Enrollment
    {
        public enum RolType
        {
            Student = 0,
            Teacher = 1
        }

        [Key]
        public int EnrollmentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public RolType Rol { get; set; }
    }
}