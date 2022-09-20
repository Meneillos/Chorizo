using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Middleware;
using Chorizo.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chorizo.Controllers
{
    [Route("/")]
    public class HelloController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Embutidos _embutidos;

        public HelloController(IConfiguration config)
        {
            //Map custom settings to a class.
            _config = config;
            _embutidos = _config.GetSection("Embutidos").Get<Embutidos>();
        }

        [HttpGet()]
        [ServiceFilter(typeof(RequestFrom))]
        public IActionResult Index()
        {
            //Read custom setting.
            return Ok(_config["Embutidos:Chorizo"]);
        }

        [HttpGet("{text}")]
        public IActionResult FromClass(string text, [FromQuery] char characterToCount)
        {
            return Ok(text.CountLetter(characterToCount));
        }

        [HttpGet("Secured")]
        [ServiceFilter(typeof(ValidateToken))]
        public IActionResult SuperSecuredEndpoint()
        {
            return Ok("You're in!");
        }

        [HttpGet("Exception")]
        public IActionResult GetException()
        {
            throw new Exception("Patata.");
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: "Zoy una ercepcion",
                statusCode: 555,
                type: "Excepcion de mierda"
            );
        }

        [HttpGet("Vehicle")]
        public ActionResult GetAllVehicles()
        {
            List<Vehicle> vehicles = new();
            Car car = new()
            {
                Brand = "Citroën",
                Model = "C4 SpaceTourer",
                EngineType = Vehicle.Engine.Combustion
            };
            Airplane plane = new()
            {
                Brand = "Airbus",
                Model = "A380",
                EngineType = Vehicle.Engine.Combustion
            };

            Debug.WriteLine(car.GetBrandModel());
            Debug.WriteLine(plane.GetBrandModel());

            vehicles.Add(car);
            vehicles.Add(plane);

            return Ok(vehicles);
        } 
    }
}