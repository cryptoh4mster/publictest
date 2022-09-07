namespace Netto.Public.DataContext.Entities
{
    public class ContactPhones
    {
        public string Country { get; set; }
        public string ForIndividuals { get; set; }
        public string CardsSupport { get; set; }

        public ICollection<Bank> Bank { get; set; }
    }
}
