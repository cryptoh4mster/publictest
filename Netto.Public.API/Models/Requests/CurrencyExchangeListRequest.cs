namespace Netto.Public.API.Models.Requests
{
    public class CurrencyExchangeListRequest
    {
        public List<string> CurrenciesFrom { get; set; }
        public List<string> CurrenciesTo { get; set; }
    }
}
