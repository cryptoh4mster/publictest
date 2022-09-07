﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Netto.Public.API.Models.Responses;

namespace Netto.Public.API.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Result)
            {
                case OkObjectResult response:
                    context.Result = new OkObjectResult(new SuccessBodyResponse<object>(response.Value));
                    break;

                case EmptyResult:
                case OkResult:
                    context.Result = new OkObjectResult(new SuccessResponse()); 
                    break;

                default:
                    break;
            }
        }
    }
}
