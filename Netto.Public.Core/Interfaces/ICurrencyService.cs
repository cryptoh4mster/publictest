namespace Netto.Public.Core.Interfaces
{
    public interface ICurrencyService
    {
        string ExchangeCurrency(string currencyFrom, string currencyTo, double amount);
        List<string> GetExchangeCurrencyList(List<string> currencyFrom, List<string> currencyTo);
    }
}
