using MediatR;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.UpdateTrader;

public record UpdateTraderCommand(
    Guid TraderId,
    string Name,
    string Email
) : IRequest<bool>;