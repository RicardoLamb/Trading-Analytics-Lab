using MediatR;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.DeleteTradingAccount;

public record DeleteTradingAccountCommand(
    Guid AcccountId
) : IRequest<bool>;