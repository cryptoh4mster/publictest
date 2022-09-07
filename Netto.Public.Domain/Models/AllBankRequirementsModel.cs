namespace Netto.Public.Domain.Models
{
    public class AllBankRequirementsModel : BankRequirementModel
    {
        public bool HasTopUp { get; set; }
        public bool HasTransfer { get; set; }
        public bool HasPayments { get; set; }
        public bool HasCurrencyExchange { get; set; }
        public bool HasWithdrawCard { get; set; }
        public bool HasTopUpWithoutCard { get; set; }
        public bool HasPandus { get; set; }
        public bool HasExoticExchange { get; set; }
        public bool HasConsultation { get; set; }
        public bool HasInsurance { get; set; }
        public bool HasWeekends { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsAllTime { get; set; }

        public static explicit operator PopularBankRequirementsModel(AllBankRequirementsModel obj)
        {
            var result = new PopularBankRequirementsModel { City = obj.City,
                HasCurrencyExchange = obj.HasCurrencyExchange,
                HasPayments = obj.HasPayments,
                HasTopUp = obj.HasTopUp,
                HasTopUpWithoutCard = obj.HasTopUpWithoutCard,
                HasTransfer = obj.HasTransfer,
                HasWithdrawCard = obj.HasWithdrawCard
            };
            return result;
        }

        public static explicit operator ExtrasRequirementsModel(AllBankRequirementsModel obj)
        {
            var result = new ExtrasRequirementsModel
            {
                City = obj.City,
                HasConsultation = obj.HasConsultation,
                HasInsurance = obj.HasInsurance,
                HasExoticExchange = obj.HasExoticExchange,
                HasPandus = obj.HasPandus
            }; 
            return result;
        }

        public static explicit operator WorkingHoursRequirementsModel(AllBankRequirementsModel obj)
        {
            var result = new WorkingHoursRequirementsModel
            {
                City = obj.City,
                IsAllTime = obj.IsAllTime,
                IsOpenNow = obj.IsOpenNow,
                HasWeekends = obj.HasWeekends
            };
            return result;
        }
    }
}
