using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;
using TradingAnalyticsLab.Application.Features.Traders.Queries.GetTraderById;

namespace TradingAnalyticsLab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradersController : ControllerBase
{
    private readonly ISender _sender;

    public TradersController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTraderCommand command)
    {
        var result =
            await _sender.Send(command);

        return Created(
            $"/api/traders/{result.TraderId}",
            result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
    Guid id)
    {
        var trader =
            await _sender.Send(
                new GetTraderByIdQuery(id));

        if (trader is null)
            return NotFound();

        return Ok(trader);
    }
}