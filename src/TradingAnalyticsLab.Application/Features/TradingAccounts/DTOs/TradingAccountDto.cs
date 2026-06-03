namespace TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

public record TradingAccountDto(
    Guid AccountId,
    Guid TraderId,
    string BrokerName,
    string AccountNumber
);