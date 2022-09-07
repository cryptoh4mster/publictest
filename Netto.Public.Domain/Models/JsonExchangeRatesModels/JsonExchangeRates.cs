using Newtonsoft.Json;

namespace Netto.Public.Domain.Models.JsonExchangeRatesModels
{
    public class JsonExchangeRates
    {
        [JsonProperty("rates")]
        public Dictionary<string, string> Rates { get; set; }
    }
}
