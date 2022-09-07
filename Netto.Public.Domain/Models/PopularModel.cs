namespace Netto.Public.Domain.Models
{
    public class PopularModel
    {
        public Guid BankId { get; set; }
        public bool HasTransfer { get; set; }
        public bool HasPayments { get; set; }
        public bool HasTopUp { get; set; }
        public bool HasCurrencyExchange { get; set; }
        public bool HasWithdrawCard { get; set; }
        public bool HasTopUpWithoutCard { get; set; }

        public BankModel Bank { get; set; }
    }
}