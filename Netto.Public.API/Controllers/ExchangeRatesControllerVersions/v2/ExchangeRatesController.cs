using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Netto.Public.Core.Interfaces;
using Netto.Public.API.Controllers.Base;
using Netto.Public.API.Models.Requests;

namespace Netto.Public.API.Controllers.ExchangeRatesControllerVersions.v2
{
    [ApiVersion("2.0")]
    public class ExchangeRatesController : BaseController
    {
        private readonly IExchangeRatesService _exchangeRatesService;

        public ExchangeRatesController(IMapper mapper, IExchangeRatesService exchangeRatesService) : base(mapper)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpPost("exchange-rates")]
        public async Task<IActionResult> GetExchangeRates([FromBody] ExchangeRatesRequest request)
        {
            var result = await _exchangeRatesService.GetExchangeRates(request.CurrenciesFrom, request.CurrencyTo);
            return Ok(result);
        }

        [HttpGet("pair-exchange-rate")]
        public async Task<IActionResult> GetPairExchangeRate([FromQuery] PairExchangeRateRequest request)
        {
            var result = await _exchangeRatesService.GetPairExchangeRate(request.CurrencyFrom, request.CurrencyTo);
            return Ok(result);
        }
    }
}
