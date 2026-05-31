namespace TradingAnalyticsLab.Application.Features.Analytics.DTOs;

public record SessionPerformanceDto(
    Guid SessionId,
    int TotalTrades,
    decimal NetResult,
    decimal WinRate
);