using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.Interfaces
{
    public interface IBankReadOnlyRepository : IReadOnlyRepository<Bank, BankModel>
    {
        Task<List<Guid>> GetAllFiltredBanksbyPopular (List<string> property, List<Guid> cityBanks);
        Task<List<Guid>> GetAllFiltredBanksbyExtras(List<string> property, List<Guid> cityBanks);
        Task<List<Guid>> GetAllFiltredBanksbyWorkingHours(List<string> property, List<Guid> cityBanks);
    }
}
