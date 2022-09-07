using Netto.Public.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Netto.Public.DataContext
{
    public class PublicDbContext : DbContext
    {
        public PublicDbContext(DbContextOptions<PublicDbContext> options) 
            : base(options) { }

        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankType> BankType { get; set; }
        public DbSet<ContactPhones> ContactPhones { get; set; }
        public DbSet<Extras> Extras { get; set; }
        public DbSet<Popular> Popular { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
