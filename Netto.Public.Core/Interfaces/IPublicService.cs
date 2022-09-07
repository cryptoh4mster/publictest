using Netto.Public.Domain.Models;

namespace Netto.Public.Core.Interfaces
{
    public interface IPublicService
    {
        Task<ContactPhonesModel> GetContactsByCountry(string country);
        Task<List<BankModel>> GetBranchesAndATMByRequirements(AllBankRequirementsModel requirements);
    }
}
