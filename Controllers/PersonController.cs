using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chorizo.Data;
using Chorizo.Interfaces;
using Chorizo.Models.School;
using Chorizo.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace Chorizo.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpPost()]
        public ActionResult NewPerson([FromBody] Person person)
        {
            try
            {
                _person.New(person);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error creating new person");
            }
        }

        [HttpGet()]
        public ActionResult<List<Person>> GetPeople([FromQuery] PersonParameters parameters)
        {
            try
            {
                return Ok(_person.GetAll(parameters));
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error getting people.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            try
            {
                Person? person = _person.Get(id);
                return person != null ? Ok(person) : BadRequest("Person doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error finding person.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                return _person.Delete(id) ? NoContent() : BadRequest("Person doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error deleting person.");
            }
        }

        [HttpPut()]
        public ActionResult UpdatePerson([FromBody] Person person)
        {
            try
            {
                return _person.Update(person) ? NoContent() : BadRequest("Person doesn't exist.");
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Error modifying person.");
            }
        }
    }
}