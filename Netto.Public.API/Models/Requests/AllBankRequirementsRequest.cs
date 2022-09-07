namespace Netto.Public.API.Models.Requests
{
    public class AllBankRequirementsRequest
    {
        public string Adress { get; set; }
        public string City { get; set; }
        public bool HasTopUp { get; set; }
        public bool HasTransfer { get; set; }
        public bool HasPayments { get; set; }
        public bool HasCurrencyExchange { get; set; }
        public bool HasWithdrawCard { get; set; }
        public bool HasTopUpWithoutCard { get; set; }
        public bool HasPandus { get; set; }
        public bool HasExoticExchange { get; set; }
        public bool HasConsultation { get; set; }
        public bool HasInsurance { get; set; }
        public bool HasWeekends { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsAllTime { get; set; }
    }
}
