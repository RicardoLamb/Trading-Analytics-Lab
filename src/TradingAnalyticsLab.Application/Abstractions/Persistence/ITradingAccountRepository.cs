using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Abstractions.Persistence;

public interface ITradingAccountRepository
{
    Task AddAsync(
        TradingAccount tradingAccount,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByTraderIdAsync(
        Guid traderId,
        CancellationToken cancellationToken = default);

    Task<TradingAccount?> GetByIdAsync(
        Guid accountId,
        CancellationToken cancellationToken = default);

    Task<List<TradingAccount>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        TradingAccount tradingAccount,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        TradingAccount tradingAccount,
        CancellationToken cancellationToken = default);
}