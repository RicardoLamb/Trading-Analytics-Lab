using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetAllTradingAccounts;

public class GetAllTradingAccountsQueryHandler
    : IRequestHandler<
        GetAllTradingAccountsQuery,
        List<TradingAccountDto>>
{
    private readonly ITradingAccountRepository _repository;

    public GetAllTradingAccountsQueryHandler(
        ITradingAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TradingAccountDto>> Handle(
        GetAllTradingAccountsQuery request,
        CancellationToken cancellationToken)
    {
        var tradingAccounts =
            await _repository.GetAllAsync(
                cancellationToken);

        return tradingAccounts
            .Select(x =>
                new TradingAccountDto(
                    x.AccountId,
                    x.TraderId,
                    x.BrokerName,
                    x.AccountNumber))
            .ToList();
    }
}