using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.Interfaces
{
    public interface IWorkingHoursReadOnlyRepository : IReadOnlyRepository<WorkingHours, WorkingHoursModel>
    {
    }
}
