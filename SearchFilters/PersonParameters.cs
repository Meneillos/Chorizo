using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.SearchFilters
{
    public class PersonParameters
    {
        private string? _name = null;
        private string? _surename = null;
        
        public string? Name { get => _name; set => _name = value!.ToLower(); }
        public string? Surename { get => _surename; set => _surename = value!.ToLower(); }
    }
}