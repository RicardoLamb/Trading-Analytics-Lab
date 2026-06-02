using MediatR;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.Traders.DTOs;

namespace TradingAnalyticsLab.Application.Features.Traders.Queries.GetAllTraders;

public class GetAllTradersQueryHandler
    : IRequestHandler<
        GetAllTradersQuery,
        List<TraderDto>>
{
    private readonly ITraderRepository _repository;

    public GetAllTradersQueryHandler(
        ITraderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TraderDto>> Handle(
        GetAllTradersQuery request,
        CancellationToken cancellationToken)
    {
        var traders =
            await _repository.GetAllAsync(
                cancellationToken);

        return traders
            .Select(x =>
                new TraderDto(
                    x.TraderId,
                    x.Name,
                    x.Email))
            .ToList();
    }
}