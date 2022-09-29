using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.SearchFilters
{
    public class SubjectParameters
    {
        private string? _name = null;
        
        public int? Course { get; set; } = null;
        public string? Name { get => _name; set => _name = value!.ToLower(); }
    }
}