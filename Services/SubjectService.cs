using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chorizo.Data;
using Chorizo.DTOs;
using Chorizo.Interfaces;
using Chorizo.Models.School;
using Chorizo.SearchFilters;
using Serilog;

namespace Chorizo.Services
{
    public class SubjectService : ISubject
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public SubjectService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void New(Subject subject)
        {
            try
            {
                _context.Subject.Add(subject);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public IEnumerable<SubjectDTO> GetAll(SubjectParameters parameters)
        {
            try
            {
                //We get the filtered subjects.
                return _mapper.Map<IEnumerable<SubjectDTO>>(_context.Subject.Where(s =>
                    (parameters.Course != null ? s.Course == parameters.Course : true) &&
                    (parameters.Name != null ? s.Name == parameters.Name : true)).ToList());

                // //For each subject we get the subject DTO and the list of teachers as List<PersonDTO>.
                // List<SubjectViewDTO> subjectViewDTOs = new();
                // foreach (var subject in subjects)
                // {
                //     SubjectViewDTO subjectView = new();
                //     //Map from Subject to SubjectDTO.
                //     subjectView.Subject = _mapper.Map<SubjectDTO>(subject);
                //     //Get all teacher ids of the subject.
                //     int[] teachersIds = _context.Enrollment.Where(e => e.SubjectId == subject.SubjectId && e.Rol == Enrollment.RolType.Teacher)
                //                               .Select(e => e.SubjectId)
                //                               .ToArray();
                //     //For each teacher we get all the data that it's mapped to PersonDTO.
                //     foreach (int teacherId in teachersIds)
                //     {
                //         Person? teacher = _context.Person.Where(p => p.PersonId == teacherId).FirstOrDefault();
                //         if (teacher != null)
                //         {
                //             var teacherDto = _mapper.Map<PersonDTO>(teacher);
                //             subjectView.Teachers.Add(teacherDto);
                //         }
                //     }
                //     subjectViewDTOs.Add(subjectView);
                // }
                // return subjectViewDTOs;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public Subject? Get(int id)
        {
            try
            {
                return _context.Subject.Where(s => s.SubjectId == id).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public SubjectViewDTO GetSubjectView(int subjectId)
        {
            var subject = _mapper.Map<SubjectDTO>(_context.Subject.Where(s => s.SubjectId == subjectId).FirstOrDefault());
            // var teachersIds = _context.Enrollment.Where(e => e.SubjectId == subjectId && e.Rol == Enrollment.RolType.Teacher)
            //                                      .Select(e => e.SubjectId)
            //                                      .ToArray();
            List<PersonDTO> teachersList = new();
            List<PersonDTO> studentsList = new();
            _context.Enrollment.Where(e => e.SubjectId == subjectId)
                               .Select(e => new { PersonID = e.PersonId, Rol = e.Rol })
                               .ToList()
                               .ForEach(x =>
                               {
                                   if (x.Rol == Enrollment.RolType.Teacher)
                                   {
                                        teachersList.Add(_mapper.Map<PersonDTO>(_context.Person.Where(p => p.PersonId == x.PersonID).First()));
                                   }
                                   else
                                   {
                                       studentsList.Add(_mapper.Map<PersonDTO>(_context.Person.Where(p => p.PersonId == x.PersonID).First()));
                                   }
                               });

            return new SubjectViewDTO()
            {
                Subject = subject,
                Teachers = teachersList,
                Students = studentsList
            };
        }

        public bool Delete(int id)
        {
            try
            {
                Subject? subjectToDelete = Get(id);
                if (subjectToDelete != null)
                {
                    _context.Subject.Remove(subjectToDelete);
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

        public bool Update(Subject subject)
        {
            try
            {
                Subject? subjectToDelete = _context.Subject.Where(s => s.SubjectId == subject.SubjectId).FirstOrDefault();
                if (subjectToDelete == null) return false;
                _context.Entry(subjectToDelete).CurrentValues.SetValues(subject);
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