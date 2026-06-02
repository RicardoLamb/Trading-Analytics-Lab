using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.UpdateTrader;

public class UpdateTraderCommandHandler
    : IRequestHandler<UpdateTraderCommand, bool>
{
    private readonly ITraderRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateTraderCommandHandler(
        ITraderRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateTraderCommand request,
        CancellationToken cancellationToken)
    {
        var trader =
            await _repository.GetByIdAsync(
                request.TraderId,
                cancellationToken);

        if (trader is null)
            return false;

        trader.Update(
            request.Name,
            request.Email);

        await _repository.UpdateAsync(
            trader,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}