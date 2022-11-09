using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chorizo.Data;
using Chorizo.DTOs;
using Chorizo.Interfaces;
using Chorizo.Models.School;
using Serilog;

namespace Chorizo.Services
{
    public class EnrollmentService : IEnrollment
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void New(Enrollment enrollment)
        {
            try
            {
                _context.Enrollment.Add(enrollment);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public IEnumerable<Enrollment> GetAll()
        {
            try
            {
                return _context.Enrollment;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public Enrollment? Get(int id)
        {
            try
            {
                return _context.Enrollment.Where(e => e.EnrollmentId == id).FirstOrDefault();
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
                Enrollment? enrollmentToDelete = Get(id);
                if (enrollmentToDelete != null)
                {
                    _context.Enrollment.Remove(enrollmentToDelete);
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

        public bool Update(Enrollment Enrollment)
        {
            try
            {
                Enrollment? enrollmentToModify = _context.Enrollment.Where(p => p.EnrollmentId == Enrollment.EnrollmentId).FirstOrDefault();
                if (enrollmentToModify == null) return false;
                _context.Entry(enrollmentToModify).CurrentValues.SetValues(Enrollment);
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