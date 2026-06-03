using MediatR;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

namespace TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetAllTradingAccounts;

public record GetAllTradingAccountsQuery
    : IRequest<List<TradingAccountDto>>;