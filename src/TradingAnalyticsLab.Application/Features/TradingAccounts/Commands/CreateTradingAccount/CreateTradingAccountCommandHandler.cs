using MediatR;

using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.CreateTradingAccount;

public class CreateTradingAccountCommandHandler
    : IRequestHandler<CreateTradingAccountCommand, TradingAccountDto>
{
    private readonly ITradingAccountRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateTradingAccountCommandHandler(
        ITradingAccountRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TradingAccountDto> Handle(
        CreateTradingAccountCommand request,
        CancellationToken cancellationToken)
    {
        var alreadyExists =
            await _repository.ExistsByTraderIdAsync(
                request.TraderId,
                cancellationToken);

        if (alreadyExists)
            throw new InvalidOperationException(
                "Trading Account already exists.");

        var tradingAccount = new TradingAccount(
            request.TraderId,
            request.BrokerName,
            request.AccountNumber);

        await _repository.AddAsync(
            tradingAccount,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new TradingAccountDto(
            tradingAccount.AccountId,
            tradingAccount.TraderId,
            tradingAccount.BrokerName,
            tradingAccount.AccountNumber);
    }
}