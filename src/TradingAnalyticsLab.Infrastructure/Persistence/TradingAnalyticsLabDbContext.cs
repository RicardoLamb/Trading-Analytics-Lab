using Microsoft.EntityFrameworkCore;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence;

public class TradingAnalyticsLabDbContext : DbContext
{
    public TradingAnalyticsLabDbContext(
        DbContextOptions<TradingAnalyticsLabDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trader> Traders => Set<Trader>();

    public DbSet<TradingAccount> TradingAccounts => Set<TradingAccount>();

    public DbSet<TradingSession> TradingSessions => Set<TradingSession>();

    public DbSet<Trade> Trades => Set<Trade>();

    public DbSet<TradingSetup> TradingSetups => Set<TradingSetup>();

    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TradingAnalyticsLabDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}