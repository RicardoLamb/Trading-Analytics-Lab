using MediatR;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.DeleteTrader;

public record DeleteTraderCommand(
    Guid TraderId
) : IRequest<bool>;