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
    public class RedisExchangeRatesService : ICurrenciesService
    {
        private readonly IDatabase _cache;

        public RedisExchangeRatesService(IDatabase cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<CurrencyModel>> GetCurrencies()
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

    }
}
