using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Infrastructure.Persistence;

public class UnitOfWork
    : IUnitOfWork
{
    private readonly TradingAnalyticsLabDbContext _context;

    public UnitOfWork(
        TradingAnalyticsLabDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(
            cancellationToken);
    }
}