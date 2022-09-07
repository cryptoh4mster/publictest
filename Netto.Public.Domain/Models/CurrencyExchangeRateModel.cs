
namespace Netto.Public.Domain.Models
{
    public class CurrencyExchangeRateModel
    {
        public CurrencyModel Currency { get; set; }
        public double BuyingExchangeRateValue { get; set; }
        public double SellingExchangeRateValue { get; set; }
    }
}
