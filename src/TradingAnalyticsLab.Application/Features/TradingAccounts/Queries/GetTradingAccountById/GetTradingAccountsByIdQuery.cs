using MediatR;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetTradingAccountById;

public record GetTradingAccountByIdQuery(
    Guid TradingAccountId)
    : IRequest<TradingAccountDto?>;