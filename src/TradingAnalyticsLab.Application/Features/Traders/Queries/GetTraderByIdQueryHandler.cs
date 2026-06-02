using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

namespace TradingAnalyticsLab.Application.Features.Traders.Queries.GetTraderById;

public class GetTraderByIdQueryHandler
    : IRequestHandler<
        GetTraderByIdQuery,
        TraderDto?>
{
    private readonly ITraderRepository _repository;

    public GetTraderByIdQueryHandler(
        ITraderRepository repository)
    {
        _repository = repository;
    }

    public async Task<TraderDto?> Handle(
        GetTraderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var trader =
            await _repository.GetByIdAsync(
                request.TraderId,
                cancellationToken);

        if (trader is null)
            return null;

        return new TraderDto(
            trader.TraderId,
            trader.Name,
            trader.Email);
    }
}