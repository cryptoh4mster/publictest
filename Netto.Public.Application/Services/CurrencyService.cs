using Microsoft.Extensions.Options;
using Netto.Public.Core.Interfaces;
using Netto.Public.Domain.Exceptions;
using Netto.Public.Domain.Models;

namespace Netto.Public.Application.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IOptions<ExchangeRateSiteProperties> settings;

        public CurrencyService(IOptions<ExchangeRateSiteProperties> settings)
        {
            this.settings = settings;
        }

        public string ExchangeCurrency(string currencyFrom, string currencyTo, double amount)
        {
            double exchangeRate = GetExchangeRate(currencyFrom, currencyTo);
            return (amount * exchangeRate).ToString();
        }

        public List<string> GetExchangeCurrencyList(List<string> currenciesFrom, List<string> currenciesTo)
        {
            var exchangeRates = new List<string>();

            for (int i = 0; i < currenciesFrom.Count; i++)
            {
                var exchangeRate = GetExchangeRate(currenciesFrom[i], currenciesTo[i]).ToString(); 
                exchangeRates.Add(exchangeRate);
            }

            return exchangeRates;
        }

        private double GetExchangeRate(string currencyFrom, string currencyTo)
        {
            using (var web = new System.Net.WebClient())
            {
                string url = string.Format($"{settings.Value.URL}{currencyFrom}-{currencyTo}");
                var json = web.DownloadString(url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(json);

                var data = doc.DocumentNode.Descendants()
               .Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == settings.Value.DivExchangeRateClass).FirstOrDefault();

                if (data == null)
                {
                    throw new WrongCurrencyISOCodeException();
                }

                return double.Parse(data.InnerText, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
