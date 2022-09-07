namespace Netto.Public.API.Models.Requests
{
    public class CurrencyExchangeRequest
    {
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public double Amount { get; set; }
    }
}
