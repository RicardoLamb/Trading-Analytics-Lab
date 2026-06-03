namespace TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

public record UpdateTradingAccountRequest(
    string BrokerName,
    string AccountNumber);