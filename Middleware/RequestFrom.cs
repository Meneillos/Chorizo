using Microsoft.AspNetCore.Mvc.Filters;

namespace Chorizo.Middleware
{
    //Custom filter.
    public class RequestFrom : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public RequestFrom(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger(typeof(RequestFrom));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Request IP is {context.HttpContext.Request.Host.Value}");
            base.OnActionExecuting(context);
        }
    }
}