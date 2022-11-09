using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.DTOs;
using Chorizo.Models.School;
using Chorizo.SearchFilters;

namespace Chorizo.Interfaces
{
    public interface ISubject
    {
        public void New(Subject subject);
        public IEnumerable<SubjectDTO> GetAll(SubjectParameters parameters);
        public Subject? Get(int id);
        public bool Delete(int id);
        public bool Update(Subject subject);
        public SubjectViewDTO GetSubjectView(int subjectId);
    }
}