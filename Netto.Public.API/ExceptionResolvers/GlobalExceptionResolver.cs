using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Netto.Public.API.ExceptionResolvers.Base;
using Netto.Public.API.Models.Responses;

namespace Netto.Public.API.ExceptionResolvers
{
    public class GlobalExceptionResolver : IExceptionResolver
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionResolver(ILogger<GlobalExceptionResolver> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var id = Guid.NewGuid();
            var errorResponse = new ErrorBodyResponse<string>
            {
                Code = 2001,
                ErrorMessage = _env.IsProduction() ? "Internal server error" : context.Exception.ToString()
            };

            _logger.LogCritical(context.Exception, $"ErrorId : {id}");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
