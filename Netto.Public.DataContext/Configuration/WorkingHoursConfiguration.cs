using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netto.Public.DataContext.Entities;

namespace Netto.Public.DataContext.Configuration
{
    public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
    {
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {
            builder.HasKey(c => c.BankId);

            builder.Property(c => c.HasWeekends).IsRequired();
            builder.Property(c => c.IsOpenNow).IsRequired();
            builder.Property(c => c.IsAllTime).IsRequired();
            builder.Property(c => c.OpenTime).IsRequired()
                .HasColumnType("date");
            builder.Property(c => c.CloseTime).IsRequired()
                .HasColumnType("date");

            builder.HasOne(p => p.Bank)
                .WithOne(c => c.WorkingHours)
                .HasForeignKey<WorkingHours>(p => p.BankId)
                .HasPrincipalKey<Bank>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
