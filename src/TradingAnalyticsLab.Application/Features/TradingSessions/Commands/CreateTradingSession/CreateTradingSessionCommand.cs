using MediatR;
using TradingAnalyticsLab.Application.Features.TradingSessions.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingSessions.Commands.CreateTradingSession;

public record CreateTradingSessionCommand(
    Guid AccountId,
    DateOnly TradingDate,
    string? Notes
) : IRequest<TradingSessionDto>;