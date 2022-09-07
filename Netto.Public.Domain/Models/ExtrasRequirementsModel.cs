namespace Netto.Public.Domain.Models
{
    public class ExtrasRequirementsModel : BankRequirementModel
    {
        public bool HasPandus { get; set; }
        public bool HasExoticExchange { get; set; }
        public bool HasConsultation { get; set; }
        public bool HasInsurance { get; set; }
    }
}
