using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradingAnalyticsLab.Api.Contracts.Traders;
using TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.CreateTradingAccount;
using TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.DeleteTradingAccount;
using TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.UpdateTradingAccount;
using TradingAnalyticsLab.Application.Features.TradingAccounts.DTOs;

// using TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.DeleteTradingAccount;
// using TradingAnalyticsLab.Application.Features.TradingAccounts.Commands.UpdateTradingAccount;
using TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetAllTradingAccounts;
using TradingAnalyticsLab.Application.Features.TradingAccounts.Queries.GetTradingAccountById;

namespace TradingAnalyticsLab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradingAccountsController : ControllerBase
{
    private readonly ISender _sender;

    public TradingAccountsController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTradingAccountCommand command)
    {
        var result =
            await _sender.Send(command);

        return Created(
            $"/api/tradingaccounts/{result.AccountId}",
            result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
    Guid id)
    {
        var tradingaccounts =
            await _sender.Send(
                new GetTradingAccountByIdQuery(id));

        if (tradingaccounts is null)
            return NotFound();

        return Ok(tradingaccounts);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tradingaccounts =
            await _sender.Send(
                new GetAllTradingAccountsQuery());

        return Ok(tradingaccounts);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTradingAccountRequest request)
    {
        var result =
            await _sender.Send(
                new UpdateTradingAccountCommand(
                    id,
                    request.BrokerName,
                    request.AccountNumber));

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
                new DeleteTradingAccountCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }
}