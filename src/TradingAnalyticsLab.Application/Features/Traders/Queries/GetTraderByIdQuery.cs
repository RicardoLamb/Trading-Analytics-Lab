using MediatR;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

namespace TradingAnalyticsLab.Application.Features.Traders.Queries.GetTraderById;

public record GetTraderByIdQuery(
    Guid TraderId)
    : IRequest<TraderDto?>;