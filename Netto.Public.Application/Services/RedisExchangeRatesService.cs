using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Netto.Public.Core.Interfaces;
using Netto.Public.Domain.Exceptions;
using Netto.Public.Domain.Models;
using Netto.Public.Domain.Models.JsonExchangeRatesModels;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Netto.Public.Application.Services
{
    public class RedisExchangeRatesService : IExchangeRatesService
    {
        private readonly HttpClient _client;
        private readonly IOptions<ExchangeRatesOptions> _options;
        private readonly IDatabase _cache;
        public RedisExchangeRatesService(HttpClient client, IOptions<ExchangeRatesOptions> options, IDatabase cache)
        {
            _client = client;
            _options = options;
            _cache = cache;
        }

        public async Task<IEnumerable<CurrencyExchangeRateModel>> GetExchangeRates(IEnumerable<string> currenciesFrom, string currencyTo)
        {
            var currenciesFromStr = string.Join(",", currenciesFrom);

            var response = await _client.GetAsync($"latest?symbols={currenciesFromStr}&base={currencyTo}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new WrongCurrencyISOCodeException();
            }

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new RequestLimitExceededException();
            }
            var responseBody = await response.Content.ReadAsStringAsync();

            var exchangeRatesDictionary = JsonConvert.DeserializeObject<JsonExchangeRates>(responseBody).Rates;

            var currenciesInfo = await GetCurrencies();

            var exchangeRatesList = from exchangeRate in exchangeRatesDictionary
                                    from currencyInfo in currenciesInfo
                                    where exchangeRate.Key == currencyInfo.Code
                                    select new CurrencyExchangeRateModel()
                                    {
                                        BuyingExchangeRateValue = Convert.ToDouble(exchangeRate.Value, CultureInfo.InvariantCulture) * Convert.ToDouble(_options.Value.BuyingCalculateConstant),
                                        SellingExchangeRateValue = Convert.ToDouble(exchangeRate.Value, CultureInfo.InvariantCulture) * Convert.ToDouble(_options.Value.SellingCalculateConstant),
                                        Currency = new CurrencyModel()
                                        {
                                            Code = currencyInfo.Code,
                                            FullName = currencyInfo.FullName
                                        }
                                    };

            return exchangeRatesList;
        }

        private async Task<IEnumerable<CurrencyModel>> GetCurrencies()
        {
            var currenciesList = new List<CurrencyModel>();

            var redisCurrenciesList = await _cache.SetMembersAsync("currencies");

            currenciesList = redisCurrenciesList.Select(currency =>
            {
                var redisCurrencyModel = JsonConvert.DeserializeObject<RedisModel>(currency);
                return new CurrencyModel()
                {
                    Code = redisCurrencyModel.Key,
                    FullName = redisCurrencyModel.Value
                };
            }).ToList();

            return currenciesList;
        }

        public async Task<double> GetPairExchangeRate(string currencyFrom, string currencyTo)
        {
            var response = await _client.GetAsync($"latest?symbols={currencyTo}&base={currencyFrom}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new WrongCurrencyISOCodeException();
            }

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new RequestLimitExceededException();
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var pairExchangeRate = JsonConvert.DeserializeObject<JsonExchangeRates>(responseBody).Rates.First().Value;

            return Convert.ToDouble(pairExchangeRate, CultureInfo.InvariantCulture);
        }
    }
}
