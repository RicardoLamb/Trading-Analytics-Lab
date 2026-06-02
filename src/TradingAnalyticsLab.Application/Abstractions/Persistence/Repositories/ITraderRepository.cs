using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Abstractions.Persistence;

public interface ITraderRepository
{
    Task AddAsync(
        Trader trader,
        CancellationToken cancellationToken = default);

    Task<Trader?> GetByIdAsync(
        Guid traderId,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}