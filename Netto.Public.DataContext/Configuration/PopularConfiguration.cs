using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class PopularConfiguration : IEntityTypeConfiguration<Popular>
    {
        public void Configure(EntityTypeBuilder<Popular> builder)
        {
            builder.HasKey(c => c.BankId);

            builder.Property(c => c.HasTransfer).IsRequired();
            builder.Property(c => c.HasPayments).IsRequired();
            builder.Property(c => c.HasTopUp).IsRequired();
            builder.Property(c => c.HasCurrencyExchange).IsRequired();
            builder.Property(c => c.HasWithdrawCard).IsRequired();
            builder.Property(c => c.HasTopUpWithoutCard).IsRequired();

            builder.HasOne(p => p.Bank)
                .WithOne(c => c.Popular)
                .HasForeignKey<Popular>(p => p.BankId)
                .HasPrincipalKey<Bank>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
