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
using Microsoft.AspNetCore.Mvc;

namespace Chorizo.Controllers
{
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subject;

        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }

        [HttpPost()]
        public ActionResult NewSubject([FromBody]Subject subject)
        {
            try
            {
                _subject.New(subject);
            return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error creating new subject");
            }
        }

        [HttpGet()]
        public ActionResult GetAll(SubjectParameters parameters)
        {
            try
            {
                return Ok(_subject.GetAll(parameters));
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error getting subject.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SubjectViewDTO> GetSubject(int id)
        {
            try
            {
                // Subject? subject = _subject.Get(id);
                SubjectViewDTO? subject = _subject.GetSubjectView(id);
                return subject != null ? Ok(subject) : BadRequest("Subject doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error finding subject.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            try
            {
                return _subject.Delete(id) ? NoContent() : BadRequest("Subject doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error deleting subject.");
            }
        }

        [HttpPut()]
        public ActionResult UpdatePerson([FromBody] Subject subject)
        {
            try
            {
                return _subject.Update(subject) ? NoContent() : BadRequest("Subject doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error modifying subject.");
            }
        }
    }
}