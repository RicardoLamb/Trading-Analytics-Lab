using MediatR;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

namespace TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;

public record CreateTraderCommand(
    string Name,
    string Email
) : IRequest<TraderDto>;