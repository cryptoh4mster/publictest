using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netto.Public.Application.Services;
using Netto.Public.Core.Interfaces;
using StackExchange.Redis;

namespace Netto.Public.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPublicService, PublicService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddHttpClient<IExchangeRatesService, ExchangeRatesService>(client =>
            {
                client.BaseAddress = new Uri(configuration["ExchangeRates:BaseURI"]);
                client.DefaultRequestHeaders.Add("apikey", configuration["ExchangeRates:ApiKey"]);
            });
            services.AddSingleton(cfg =>
            {
                ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configuration["ConnectionStrings:RedisCacheURL"]);
                return multiplexer.GetDatabase();
            });
        }
    }
}
