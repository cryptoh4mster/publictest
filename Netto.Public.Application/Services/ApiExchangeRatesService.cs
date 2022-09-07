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
    public class ApiExchangeRatesService : ICurrenciesService
    {
        private readonly HttpClient _client;

        public ApiExchangeRatesService(HttpClient client, IOptions<ExchangeRatesOptions> options, IDatabase cache)
        {
            _client = client;
        }

        public async Task<IEnumerable<CurrencyModel>> GetCurrencies()
        {
            var currenciesList = new List<CurrencyModel>();

            var response = await _client.GetAsync("symbols");

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new RequestLimitExceededException();
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var currenciesDictionary = JsonConvert.DeserializeObject<JsonCurrencies>(responseBody).Symbols;

            currenciesList = currenciesDictionary.Select(currency =>
            {
                return new CurrencyModel()
                {
                    Code = currency.Key,
                    FullName = currency.Value
                };
            }).ToList();

            return currenciesList;
        }
    }
}
