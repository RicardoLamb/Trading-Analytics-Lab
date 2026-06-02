using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public sealed class TradingSessionConfiguration
    : IEntityTypeConfiguration<TradingSession>
{
    public void Configure(
        EntityTypeBuilder<TradingSession> builder)
    {
        builder.ToTable("trading_sessions");

        builder.HasKey(x => x.SessionId);
    }
}