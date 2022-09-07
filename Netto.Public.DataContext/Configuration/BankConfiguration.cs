using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Number).IsUnique();

            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.GeoLat).IsRequired();
            builder.Property(c => c.GeoLong).IsRequired();
            builder.Property(c => c.City).IsRequired();
            builder.Property(c => c.Number).IsRequired();

            builder.HasOne(c => c.BankType)
                .WithMany(o => o.Bank)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            builder.HasOne(c => c.ContactPhones)
                .WithMany(o => o.Bank)
                .HasForeignKey(c => c.Country)
                .HasPrincipalKey(u => u.Country)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
