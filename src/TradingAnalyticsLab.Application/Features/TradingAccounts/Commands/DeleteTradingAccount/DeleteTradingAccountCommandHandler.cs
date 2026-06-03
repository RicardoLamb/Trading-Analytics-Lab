using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.DeleteTradingAccount;

public class DeleteTradingAccountCommandHandler
    : IRequestHandler<DeleteTradingAccountCommand, bool>
{
    private readonly ITradingAccountRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteTradingAccountCommandHandler(
        ITradingAccountRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteTradingAccountCommand request,
        CancellationToken cancellationToken)
    {
        var tradinAccount =
            await _repository.GetByIdAsync(
                request.AcccountId,
                cancellationToken);

        if (tradinAccount is null)
            return false;

        await _repository.DeleteAsync(
            tradinAccount,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}