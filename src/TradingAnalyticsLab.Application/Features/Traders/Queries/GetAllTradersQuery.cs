using MediatR;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

namespace TradingAnalyticsLab.Application.Features.Traders.Queries.GetAllTraders;

public record GetAllTradersQuery
    : IRequest<List<TraderDto>>;