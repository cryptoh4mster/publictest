using AutoMapper;
using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.ReadOnlyRepositories
{
    public class ExtrasReadOnlyRepository : ReadOnlyRepositoryBase<Extras, ExtrasModel>, IExtrasReadOnlyRepository
    {
        public ExtrasReadOnlyRepository(PublicDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
