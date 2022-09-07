using Netto.Public.API.ExceptionResolvers;
using Netto.Public.API.ExceptionResolvers.Base;
using Netto.Public.Domain.Exceptions;

namespace Netto.Public.API.Extensions
{
    public static class ExceptionFilterDI
    {
        public static void AddExceptionsFilter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExceptionResolver, GlobalExceptionResolver>();
            services.AddScoped<IExceptionResolver<NoBranchesAndATMException>, NoBranchesAndATMExceptionResolver>();
            services.AddScoped<IExceptionResolver<ContactsNotFoundException>, ContactsNotFoundExceptionResolver>();
            services.AddScoped<IExceptionResolver<WrongCurrencyISOCodeException>, WrongCurrencyISOCodeExceptionResolver>();
            services.AddScoped<IExceptionResolver<RequestLimitExceededException>, RequestLimitExceededExceptionResolver>();
        }
    }
}
