using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.DTOs
{
    public class SubjectViewDTO
    {
        public SubjectDTO Subject { get; set; } = new();
        public List<PersonDTO> Teachers { get; set; } = new();
        public List<PersonDTO> Students { get; set; } = new();
    }
}