using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.DTOs;
using Chorizo.Models.School;

namespace Chorizo.Interfaces
{
    public interface IEnrollment
    {
        public void New(Enrollment enrollment);       
        public IEnumerable<Enrollment> GetAll();
        public Enrollment? Get(int id);
        public bool Delete(int id);
        public bool Update(Enrollment enrollment);
    }
}