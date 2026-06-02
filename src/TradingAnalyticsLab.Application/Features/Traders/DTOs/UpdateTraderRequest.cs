namespace TradingAnalyticsLab.Api.Contracts.Traders;

public record UpdateTraderRequest(
    string Name,
    string Email);