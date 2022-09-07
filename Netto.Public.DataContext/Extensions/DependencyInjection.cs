using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netto.Public.DataContext.Repositories.Interfaces;
using Netto.Public.DataContext.Repositories.ReadOnlyRepositories;

namespace Netto.Public.DataContext.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<PublicDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("IdentityConnection"),
                    b => b.MigrationsAssembly("Netto.Public.DataContext")));
            services.AddScoped<PublicDbContext>();
            services.AddScoped<IBankReadOnlyRepository, BankReadOnlyRepository>();
            services.AddScoped<IPopularReadOnlyRepository, PopularReadOnlyRepository>();
            services.AddScoped<IContactPhonesReadOnlyRepository, ContactPhonesReadOnlyRepository>();
            services.AddScoped<IExtrasReadOnlyRepository, ExtrasReadOnlyRepository>();
            services.AddScoped<IWorkingHoursReadOnlyRepository, WorkingHoursReadOnlyRepository>();
        }
    }
}
