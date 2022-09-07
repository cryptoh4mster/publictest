using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class BankTypeConfiguration : IEntityTypeConfiguration<BankType>
    {
        public void Configure(EntityTypeBuilder<BankType> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
