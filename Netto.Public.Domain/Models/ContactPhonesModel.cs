namespace Netto.Public.Domain.Models
{
    public class ContactPhonesModel
    {
        public string Country { get; set; }
        public string ForIndividuals { get; set; }
        public string CardsSupport { get; set; }

        public BankModel Bank { get; set; }
    }
}