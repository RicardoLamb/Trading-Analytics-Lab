using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradingAnalyticsLab.Api.Contracts.Traders;
using TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;
using TradingAnalyticsLab.Application.Features.Traders.Commands.DeleteTrader;
using TradingAnalyticsLab.Application.Features.Traders.Commands.UpdateTrader;
using TradingAnalyticsLab.Application.Features.Traders.Queries.GetAllTraders;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var traders =
            await _sender.Send(
                new GetAllTradersQuery());

        return Ok(traders);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTraderRequest request)
    {
        var result =
            await _sender.Send(
                new UpdateTraderCommand(
                    id,
                    request.Name,
                    request.Email));

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var result =
            await _sender.Send(
                new DeleteTraderCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }
}