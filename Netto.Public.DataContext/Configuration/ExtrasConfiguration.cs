using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class ExtrasConfiguration : IEntityTypeConfiguration<Extras>
    {
        public void Configure(EntityTypeBuilder<Extras> builder)
        {
            builder.HasKey(c => c.BankId);

            builder.Property(c => c.HasPandus).IsRequired();
            builder.Property(c => c.HasExoticExchange).IsRequired();
            builder.Property(c => c.HasConsultation).IsRequired();
            builder.Property(c => c.HasInsurance).IsRequired();

            builder.HasOne(p => p.Bank)
                .WithOne(c => c.Extras)
                .HasForeignKey<Extras>(p => p.BankId)
                .HasPrincipalKey<Bank>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
