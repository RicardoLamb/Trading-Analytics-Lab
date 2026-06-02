using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public sealed class TradingAccountConfiguration
    : IEntityTypeConfiguration<TradingAccount>
{
    public void Configure(
        EntityTypeBuilder<TradingAccount> builder)
    {
        builder.ToTable("trading_accounts");

        builder.HasKey(x => x.AccountId);
    }
}