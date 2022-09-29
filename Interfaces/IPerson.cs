using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Models.School;
using Chorizo.SearchFilters;

namespace Chorizo.Interfaces
{
    public interface IPerson
    {
        public void New(Person person);
        public IEnumerable<Person> GetAll(PersonParameters parameters);
        public Person? Get(int id);
        public bool Delete(int id);
        public bool Update(Person person);
    }
}