using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Netto.Public.API.Controllers.Base;
using Netto.Public.API.Models.Requests;
using Netto.Public.Core.Interfaces;
using System.Text.RegularExpressions;

namespace Netto.Public.API.Controllers.CurrencyControllerVersions.v1
{
    [ApiVersion("1.0")]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(IMapper mapper, ICurrencyService currencyService) : base(mapper)
        {
            _currencyService = currencyService;
        }

        [HttpPost("currency-exchange")]
        public async Task<IActionResult> ExchangeCurrency(CurrencyExchangeRequest request)
        {
            var result = _currencyService.ExchangeCurrency(request.CurrencyFrom, request.CurrencyTo, request.Amount);
            return Ok(result);
        }

        [HttpPost("currency-exchange/list")]
        public async Task<IActionResult> ExchangeCurrencyList(CurrencyExchangeListRequest request)
        {
            var result = _currencyService.GetExchangeCurrencyList(request.CurrenciesFrom, request.CurrenciesTo);
            return Ok(result);
        }
    }
}
