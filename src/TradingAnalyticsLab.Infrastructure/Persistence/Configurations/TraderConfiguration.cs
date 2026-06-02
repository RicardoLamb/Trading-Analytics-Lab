using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public class TraderConfiguration
    : IEntityTypeConfiguration<Trader>
{
    public void Configure(
        EntityTypeBuilder<Trader> builder)
    {
        builder.ToTable("traders");

        builder.HasKey(x => x.TraderId);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(200)
            .IsRequired();
    }
}