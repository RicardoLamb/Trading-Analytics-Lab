using Microsoft.EntityFrameworkCore;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Repositories;

public class TradingAccountRepository
    : ITradingAccountRepository
{
    private readonly TradingAnalyticsLabDbContext _context;

    public TradingAccountRepository(
        TradingAnalyticsLabDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        TradingAccount accountId,
        CancellationToken cancellationToken = default)
    {
        await _context.TradingAccounts.AddAsync(
            accountId,
            cancellationToken);
    }

    public async Task<bool> ExistsByTraderIdAsync(
        Guid traderId,
        CancellationToken cancellationToken = default)
    {
        return await _context.TradingAccounts
            .AnyAsync(
                x => x.TraderId == traderId,
                cancellationToken);
    }

    public async Task<TradingAccount?> GetByIdAsync(
        Guid accountId,
        CancellationToken cancellationToken = default)
    {
        return await _context.TradingAccounts
            .FirstOrDefaultAsync(
                x => x.AccountId == accountId,
                cancellationToken);
    }

    public async Task<List<TradingAccount>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.TradingAccounts
            .AsNoTracking()
            .OrderBy(x => x.BrokerName)
            .ToListAsync(cancellationToken);
    }

    public Task UpdateAsync(
        TradingAccount tradingAccount,
        CancellationToken cancellationToken = default)
    {
        _context.TradingAccounts.Update(tradingAccount);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(
        TradingAccount tradingAccount,
        CancellationToken cancellationToken = default)
    {
        _context.TradingAccounts.Remove(tradingAccount);

        return Task.CompletedTask;
    }
}