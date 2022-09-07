using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Netto.Public.API.Models.Responses;

namespace Netto.Public.API.Filters
{
    public class ValidatorActionFilter : IActionFilter, IFilterMetadata
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                filterContext.Result = new ObjectResult(new ErrorBodyResponse<object>() { Code = 004, Body = filterContext.ModelState });
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
