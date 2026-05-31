using MediatR;
using TradingAnalyticsLab.Application.Features.Analytics.DTOs;

namespace TradingAnalyticsLab.Application.Features.Analytics.Queries.GetSessionPerformance;

public record GetSessionPerformanceQuery(
    Guid SessionId
) : IRequest<SessionPerformanceDto>;