namespace Netto.Public.DataContext.Entities
{
    public class Bank
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public BankType BankType { get; set; }
        public ContactPhones ContactPhones { get; set; }
        public Popular Popular { get; set; }
        public WorkingHours WorkingHours { get; set; }
        public Extras Extras { get; set; }
    }
}
