using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Netto.Public.DataContext.Entities;
using Netto.Public.DataContext.Repositories.Base;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.Domain.Models;

namespace Netto.Public.DataContext.Repositories.ReadOnlyRepositories
{
    public class PopularReadOnlyRepository : ReadOnlyRepositoryBase<Popular, PopularModel>, IPopularReadOnlyRepository
    {
        public PopularReadOnlyRepository(PublicDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
