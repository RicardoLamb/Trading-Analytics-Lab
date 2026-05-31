namespace TradingAnalyticsLab.Application.Features.Traders.DTOs;

public record TraderDto(
    Guid TraderId,
    string Name,
    string Email
);