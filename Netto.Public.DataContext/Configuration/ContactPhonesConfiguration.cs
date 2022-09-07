using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class ContactPhonesConfiguration : IEntityTypeConfiguration<ContactPhones>
    {
        public void Configure(EntityTypeBuilder<ContactPhones> builder)
        {
            builder.HasKey(c => c.Country);

            builder.Property(c => c.ForIndividuals).IsRequired();
            builder.Property(c => c.CardsSupport).IsRequired();
        }
    }
}
