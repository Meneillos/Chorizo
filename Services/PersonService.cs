using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chorizo.Data;
using Chorizo.Interfaces;
using Chorizo.Models.School;
using Chorizo.SearchFilters;
using Serilog;

namespace Chorizo.Services
{
    public class PersonService : IPerson
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void New(Person person)
        {
            try
            {
                _context.Person.Add(person);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public IEnumerable<Person> GetAll(PersonParameters parameters)
        {
            try
            {
                return _context.Person.Where(p => 
                    (parameters.Name != null ? p.Name!.Contains(parameters.Name) : true) &&
                    (parameters.Surename != null ? p.Surename!.Contains(parameters.Surename) : true)
                    );
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public Person? Get(int id)
        {
            try
            {
                return _context.Person.Where(p => p.PersonId == id).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Person? personToDelete = Get(id);
                if (personToDelete != null)
                {
                    _context.Person.Remove(personToDelete);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public bool Update(Person person)
        {
            try
            {
                Person? personToModify = _context.Person.Where(p => p.PersonId == person.PersonId).FirstOrDefault();
                if (personToModify == null) return false;
                _context.Entry(personToModify).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }
    }
}