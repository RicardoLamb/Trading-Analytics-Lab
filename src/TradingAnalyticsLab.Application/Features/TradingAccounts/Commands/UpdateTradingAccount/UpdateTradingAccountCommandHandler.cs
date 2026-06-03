using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.UpdateTradingAccount;

public class UpdateTradingAccountCommandHandler
    : IRequestHandler<UpdateTradingAccountCommand, bool>
{
    private readonly ITradingAccountRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateTradingAccountCommandHandler(
        ITradingAccountRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateTradingAccountCommand request,
        CancellationToken cancellationToken)
    {
        var tradingAccount =
            await _repository.GetByIdAsync(
                request.AccountId,
                cancellationToken);

        if (tradingAccount is null)
            return false;

        tradingAccount.Update(
            request.BrokerName,
            request.AccountNumber);

        await _repository.UpdateAsync(
            tradingAccount,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}