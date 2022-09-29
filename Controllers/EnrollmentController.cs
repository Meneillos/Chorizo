using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Interfaces;
using Chorizo.Models.School;
using Microsoft.AspNetCore.Mvc;

namespace Chorizo.Controllers
{
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _enrollment;

        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }

        [HttpPost()]
        public ActionResult NewEnrollment([FromBody] Enrollment enrollment)
        {
            try
            {
                _enrollment.New(enrollment);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error creating new enrollment");
            }
        }

        [HttpGet()]
        public ActionResult<List<Enrollment>> GetEnrollments()
        {
            try
            {
                return Ok(_enrollment.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error getting enrollments.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollment(int id)
        {
            try
            {
                Enrollment? enrollment = _enrollment.Get(id);
                return enrollment != null ? Ok(enrollment) : BadRequest("Enrollment doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error finding enrollment.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEnrollment(int id)
        {
            try
            {
                return _enrollment.Delete(id) ? NoContent() : BadRequest("Enrollment doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error deleting enrollment.");
            }
        }

        [HttpPut()]
        public ActionResult UpdateEnrollment([FromBody] Enrollment enrollment)
        {
            try
            {
                return _enrollment.Update(enrollment) ? NoContent() : BadRequest("Enrollment doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error modifying enrollment.");
            }
        }
    }
}