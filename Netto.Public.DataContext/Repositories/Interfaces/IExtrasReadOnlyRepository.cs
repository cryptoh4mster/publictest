using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.Interfaces
{
    public interface IExtrasReadOnlyRepository : IReadOnlyRepository<Extras, ExtrasModel>
    {
    }
}
