using Microsoft.AspNetCore.Mvc.Filters;

namespace Netto.Public.API.ExceptionResolvers.Base
{
    public interface IExceptionResolver<T> : IExceptionResolver where T : Exception
    {
    }

    public interface IExceptionResolver
    {
        void OnException(ExceptionContext context);
    }
}
