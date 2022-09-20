using Chorizo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Chorizo.Middleware
{
    public class ValidateToken : ActionFilterAttribute
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public ValidateToken(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _config = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("Token", out StringValues tokenHeader) &&
            _tokenService.ShowAll().Where(t => t.Value.ToString() == tokenHeader && t.TokenAddress == context.HttpContext.Request.Host.Host).Any())
            {
                base.OnActionExecuting(context);
            }
            else context.Result = new UnauthorizedObjectResult(_config["Messages:Unauthorized"]);
        }
    }
}