using TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;

namespace TradingAnalyticsLab.UnitTests.Application;

public class CreateTraderCommandHandlerTests
{
    [Fact]
    public async Task Should_Create_Trader()
    {
        var handler = new CreateTraderCommandHandler();

        var command = new CreateTraderCommand(
            "Ricardo Lamb",
            "ricardo@email.com");

        var result = await handler.Handle(
            command,
            CancellationToken.None);

        Assert.Equal(
            "Ricardo Lamb",
            result.Name);
    }
}