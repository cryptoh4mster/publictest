using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Netto.Public.API.ExceptionResolvers.Base;
using Netto.Public.API.Models.Responses;
using Netto.Public.Domain.Exceptions;

namespace Netto.Public.API.ExceptionResolvers
{
    public class NoBranchesAndATMExceptionResolver : IExceptionResolver<NoBranchesAndATMException>
    {
        private readonly ILogger _logger;
        public NoBranchesAndATMExceptionResolver(ILogger<NoBranchesAndATMExceptionResolver> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var errorResponse = new ErrorResponse { Code = 4015, ErrorMessage = context.Exception.Message };

            _logger.LogInformation(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
