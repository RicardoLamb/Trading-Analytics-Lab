using MediatR;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;

public class CreateTraderCommandHandler
    : IRequestHandler<CreateTraderCommand, TraderDto>
{
    public Task<TraderDto> Handle(
        CreateTraderCommand request,
        CancellationToken cancellationToken)
    {
        var trader = new Trader(
            request.Name,
            request.Email);

        var dto = new TraderDto(
            trader.TraderId,
            trader.Name,
            trader.Email);

        return Task.FromResult(dto);
    }
}