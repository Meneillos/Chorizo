using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chorizo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private List<Teacher> TeacherList = new();

        [HttpPost("Teacher")]
        public ActionResult NewTeacher([FromBody] Teacher teacher)
        {
            TeacherList.Add(teacher);
            return NoContent();
        }
    }
}