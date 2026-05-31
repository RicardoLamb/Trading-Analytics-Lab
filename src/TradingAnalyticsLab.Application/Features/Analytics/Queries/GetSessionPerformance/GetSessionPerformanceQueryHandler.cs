using MediatR;
using TradingAnalyticsLab.Application.Features.Analytics.DTOs;
using TradingAnalyticsLab.Domain.Entities;
using TradingAnalyticsLab.Domain.Enums;

namespace TradingAnalyticsLab.Application.Features.Analytics.Queries.GetSessionPerformance;

public class GetSessionPerformanceQueryHandler
    : IRequestHandler<GetSessionPerformanceQuery, SessionPerformanceDto>
{
    public Task<SessionPerformanceDto> Handle(
        GetSessionPerformanceQuery request,
        CancellationToken cancellationToken)
    {
        var session = new TradingSession(
            Guid.NewGuid(),
            DateOnly.FromDateTime(DateTime.Today));

        session.AddTrade(
            new Trade(
                session.SessionId,
                "WIN",
                TradeDirection.Buy,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(5),
                100,
                80,
                1));

        session.AddTrade(
            new Trade(
                session.SessionId,
                "WIN",
                TradeDirection.Buy,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(3),
                -50,
                -70,
                1));

        var dto = new SessionPerformanceDto(
            session.SessionId,
            session.Trades.Count,
            session.GetNetResult(),
            session.GetWinRate());

        return Task.FromResult(dto);
    }
}