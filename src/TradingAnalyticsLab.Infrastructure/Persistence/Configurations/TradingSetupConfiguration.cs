using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public sealed class TradingSetupConfiguration
    : IEntityTypeConfiguration<TradingSetup>
{
    public void Configure(
        EntityTypeBuilder<TradingSetup> builder)
    {
        builder.ToTable("trading_setups");

        builder.HasKey(x => x.SetupId);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}