using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.ReadOnlyRepositories
{
    public class WorkingHoursReadOnlyRepository : ReadOnlyRepositoryBase<WorkingHours, WorkingHoursModel>, IWorkingHoursReadOnlyRepository
    {
        public WorkingHoursReadOnlyRepository(PublicDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
