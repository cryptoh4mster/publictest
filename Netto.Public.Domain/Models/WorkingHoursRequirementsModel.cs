namespace Netto.Public.Domain.Models
{
    public class WorkingHoursRequirementsModel : BankRequirementModel
    {
        public bool HasWeekends { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsAllTime { get; set; }
    }
}
