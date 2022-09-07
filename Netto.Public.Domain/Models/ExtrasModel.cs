namespace Netto.Public.Domain.Models
{
    public class ExtrasModel
    {
        public Guid BankId { get; set; }
        public bool HasPandus { get; set; }
        public bool HasExoticExchange { get; set; }
        public bool HasConsultation { get; set; }
        public bool HasInsurance { get; set; }

        public BankModel Bank { get; set; }
    }
}