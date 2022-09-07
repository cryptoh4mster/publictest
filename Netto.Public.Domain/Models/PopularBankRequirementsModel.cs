namespace Netto.Public.Domain.Models
{
    public class PopularBankRequirementsModel : BankRequirementModel
    {
        public bool HasTopUp { get; set; }
        public bool HasTransfer { get; set; }
        public bool HasPayments { get; set; }
        public bool HasCurrencyExchange { get; set; }
        public bool HasWithdrawCard { get; set; }
        public bool HasTopUpWithoutCard { get; set; }
    }
}
