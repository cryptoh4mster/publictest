using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.ReadOnlyRepositories
{
    public class BankReadOnlyRepository : ReadOnlyRepositoryBase<Bank, BankModel>, IBankReadOnlyRepository
    {
        public BankReadOnlyRepository(PublicDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<List<Guid>> GetAllFiltredBanksbyPopular(List<string> property, List<Guid> cityBanks)
        {
            var banksPopulr = await AuthDbContext.Popular.Select(p => p).Where(p => cityBanks.Contains(p.BankId)).ToListAsync();
            return banksPopulr
                .Where(popul => property.All(p => (bool)popul.GetType().GetProperty(p).GetValue(popul) == true))
                .Select(p => p.BankId).ToList();
        }

        public async Task<List<Guid>> GetAllFiltredBanksbyExtras(List<string> property, List<Guid> cityBanks)
        {
            var banksPopulr = await AuthDbContext.Extras.Select(p => p).Where(p => cityBanks.Contains(p.BankId)).ToListAsync();
            return banksPopulr
                .Where(popul => property.All(p => (bool)popul.GetType().GetProperty(p).GetValue(popul) == true))
                .Select(p => p.BankId).ToList();
        }

        public async Task<List<Guid>> GetAllFiltredBanksbyWorkingHours(List<string> property, List<Guid> cityBanks)
        {
            var banksPopulr = await AuthDbContext.WorkingHours.Select(p => p).Where(p => cityBanks.Contains(p.BankId)).ToListAsync();
            return banksPopulr
                .Where(popul => property.All(p => (bool)popul.GetType().GetProperty(p).GetValue(popul) == true))
                .Select(p => p.BankId).ToList();
        }
    }
}
