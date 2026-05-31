using MediatR;
using TradingAnalyticsLab.Application.Features.TradingSessions.DTOs;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Application.Features.TradingSessions.Commands.CreateTradingSession;

public class CreateTradingSessionCommandHandler
    : IRequestHandler<CreateTradingSessionCommand, TradingSessionDto>
{
    public Task<TradingSessionDto> Handle(
        CreateTradingSessionCommand request,
        CancellationToken cancellationToken)
    {
        var session = new TradingSession(
            request.AccountId,
            request.TradingDate,
            request.Notes);

        var dto = new TradingSessionDto(
            session.SessionId,
            session.AccountId,
            session.TradingDate,
            session.Notes);

        return Task.FromResult(dto);
    }
}