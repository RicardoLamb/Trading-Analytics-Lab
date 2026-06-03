using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetTradingAccountById;

public class GetTradingAccountsByIdQueryHandler
    : IRequestHandler<
        GetTradingAccountByIdQuery,
        TradingAccountDto?>
{
    private readonly ITradingAccountRepository _repository;

    public GetTradingAccountsByIdQueryHandler(
        ITradingAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<TradingAccountDto?> Handle(
        GetTradingAccountByIdQuery request,
        CancellationToken cancellationToken)
    {
        var tradingAccount =
            await _repository.GetByIdAsync(
                request.TradingAccountId,
                cancellationToken);

        if (tradingAccount is null)
            return null;

        return new TradingAccountDto(
            tradingAccount.AccountId,
            tradingAccount.TraderId,
            tradingAccount.BrokerName,
            tradingAccount.AccountNumber);
    }
}