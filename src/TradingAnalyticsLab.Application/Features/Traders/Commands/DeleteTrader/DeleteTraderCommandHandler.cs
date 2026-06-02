using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.DeleteTrader;

public class DeleteTraderCommandHandler
    : IRequestHandler<DeleteTraderCommand, bool>
{
    private readonly ITraderRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteTraderCommandHandler(
        ITraderRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteTraderCommand request,
        CancellationToken cancellationToken)
    {
        var trader =
            await _repository.GetByIdAsync(
                request.TraderId,
                cancellationToken);

        if (trader is null)
            return false;

        await _repository.DeleteAsync(
            trader,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}