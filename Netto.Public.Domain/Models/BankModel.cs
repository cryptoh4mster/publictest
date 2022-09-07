namespace Netto.Public.Domain.Models
{
    public class BankModel
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public BankTypeModel BankType { get; set; }
        public ContactPhonesModel ContactPhones { get; set; }
        public PopularModel Popular { get; set; }
        public WorkingHoursModel WorkingHours { get; set; }
        public ExtrasModel Extras { get; set; }
    }
}
