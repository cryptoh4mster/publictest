namespace Netto.Public.API.Models.Requests
{
    public class ExchangeRatesRequest
    {
        public IEnumerable<string> CurrenciesFrom { get; set; }
        public string CurrencyTo { get; set; }
    }
}
