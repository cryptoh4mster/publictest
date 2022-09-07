﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Netto.Public.DataContext.Extensions;
using System.Linq.Expressions;

namespace Netto.Public.DataContext.Repositories.Base
{
    public abstract class ReadOnlyRepositoryBase<TEntity, TModel> : IReadOnlyRepository<TEntity, TModel>
        where TEntity : class
    {
        protected readonly PublicDbContext AuthDbContext;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IMapper Mapper;

        protected ReadOnlyRepositoryBase(
            PublicDbContext context,
            IMapper mapper)
        {
            AuthDbContext = context;
            DbSet = context.Set<TEntity>();
            Mapper = mapper;
        }

        public async Task<TModel[]> FindAll()
        {
            var result = await DbSet
                .AsNoTracking()
                .ToArrayAsync();

            return Mapper.Map<TModel[]>(result);
        }

        public async Task<TModel[]> FindAll(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await DbSet
                .Where(expression)
                .IncludeMultiple(includes)
                .AsNoTracking()
                .ToArrayAsync();

            return Mapper.Map<TModel[]>(result);
        }

        public async Task<TModel?> FindByPropertyOrDefault(string propertyName, object propertyValue)
        {
            var result = await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(u => propertyValue.Equals(EF.Property<string>(u, propertyName)));

            return Mapper.Map<TModel?>(result);
        }

        public async Task<TModel?> FindByPropertyOrDefaultIncludes(string propertyName, object propertyValue, 
            params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await DbSet.AsNoTracking()
                .IncludeMultiple(includes)
                .FirstOrDefaultAsync(u => propertyValue.Equals(EF.Property<string>(u, propertyName)));

            return Mapper.Map<TModel>(result);
        }
    }
}
