using Chorizo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chorizo.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return Ok(_tokenService.ShowAll());
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return Ok(_tokenService.New(Request.Host.Host));
        }
    }
}