using MediatR;

using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;

public class CreateTraderCommandHandler
    : IRequestHandler<CreateTraderCommand, TraderDto>
{
    private readonly ITraderRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateTraderCommandHandler(
        ITraderRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TraderDto> Handle(
        CreateTraderCommand request,
        CancellationToken cancellationToken)
    {
        var alreadyExists =
            await _repository.ExistsByEmailAsync(
                request.Email,
                cancellationToken);

        if (alreadyExists)
            throw new InvalidOperationException(
                "Trader already exists.");

        var trader = new Trader(
            request.Name,
            request.Email);

        await _repository.AddAsync(
            trader,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new TraderDto(
            trader.TraderId,
            trader.Name,
            trader.Email);
    }
}