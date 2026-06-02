using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Infrastructure.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly TradingAnalyticsLabDbContext _context;

    public UnitOfWork(
        TradingAnalyticsLabDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(
            cancellationToken);
    }
}