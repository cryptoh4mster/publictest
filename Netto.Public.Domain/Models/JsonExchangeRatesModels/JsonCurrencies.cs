using Newtonsoft.Json;

namespace Netto.Public.Domain.Models.JsonExchangeRatesModels
{
    public class JsonCurrencies
    {
        [JsonProperty("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
