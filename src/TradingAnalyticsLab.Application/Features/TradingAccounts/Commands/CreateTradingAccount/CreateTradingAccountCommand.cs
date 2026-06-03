using MediatR;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.CreateTradingAccount;

public record CreateTradingAccountCommand(
    Guid TraderId,
    string BrokerName,
    string AccountNumber
) : IRequest<TradingAccountDto>;