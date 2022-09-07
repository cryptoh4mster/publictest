using Netto.Public.Domain.Models;

namespace Netto.Public.Core.Interfaces
{
    public interface IExchangeRatesService
    {
        Task<IEnumerable<CurrencyExchangeRateModel>> GetExchangeRates(IEnumerable<string> currenciesFrom, string currencyTo);
        Task<double> GetPairExchangeRate(string currencyFrom, string currencyTo);
    }
}
