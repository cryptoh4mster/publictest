namespace Netto.Public.Domain.Models
{
    public class WorkingHoursModel
    {
        public Guid BankId { get; set; }
        public bool HasWeekends { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsAllTime { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

        public BankModel Bank { get; set; }
    }
}