namespace Netto.Public.Domain.Models
{
    public class BankTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BankModel Bank { get; set; }
    }
}