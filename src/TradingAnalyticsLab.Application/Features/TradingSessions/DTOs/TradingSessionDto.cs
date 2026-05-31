namespace TradingAnalyticsLab.Application.Features.TradingSessions.DTOs;

public record TradingSessionDto(
    Guid SessionId,
    Guid AccountId,
    DateOnly TradingDate,
    string? Notes
);