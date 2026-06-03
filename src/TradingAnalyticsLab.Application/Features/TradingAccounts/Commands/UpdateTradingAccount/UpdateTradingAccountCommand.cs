using MediatR;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.UpdateTradingAccount;

public record UpdateTradingAccountCommand(
    Guid AccountId,
    string BrokerName,
    string AccountNumber
) : IRequest<bool>;