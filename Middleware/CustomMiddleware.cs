//Create custom middleware.
using System.Diagnostics;

namespace Chorizo.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(CustomMiddleware));
        }

        public async Task InvokeAsync(HttpContext httpContext, IConfiguration config)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();
            Guid traceId = Guid.NewGuid();
            httpContext.Response.OnStarting((patata) =>
            {
                //Read custom settings.
                string calcetin = config["Headers:Calcetin"];
                if (!String.IsNullOrWhiteSpace(calcetin))
                    //Add custom headers.
                    httpContext.Response.Headers.Add("Calcetin", config["Headers:Calcetin"]);
                return Task.CompletedTask;
            }, httpContext);
            await _next(httpContext);
            stopWatch.Stop();
            //Log to debug console.
            _logger.LogInformation($"Request {traceId} has taken {stopWatch.ElapsedMilliseconds}ms");
        }
    }
}