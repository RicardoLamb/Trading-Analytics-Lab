using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public sealed class TradeConfiguration
    : IEntityTypeConfiguration<Trade>
{
    public void Configure(
        EntityTypeBuilder<Trade> builder)
    {
        builder.ToTable("trades");

        builder.HasKey(x => x.TradeId);
    }
}