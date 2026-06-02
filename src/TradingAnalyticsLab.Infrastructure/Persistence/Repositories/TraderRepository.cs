using Microsoft.EntityFrameworkCore;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Repositories;

public class TraderRepository
    : ITraderRepository
{
    private readonly TradingAnalyticsLabDbContext _context;

    public TraderRepository(
        TradingAnalyticsLabDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Trader trader,
        CancellationToken cancellationToken = default)
    {
        await _context.Traders.AddAsync(
            trader,
            cancellationToken);
    }

    public async Task<Trader?> GetByIdAsync(
        Guid traderId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Traders
            .FirstOrDefaultAsync(
                x => x.TraderId == traderId,
                cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _context.Traders
            .AnyAsync(
                x => x.Email == email,
                cancellationToken);
    }

    public async Task<List<Trader>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Traders
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}