using TradingAnalyticsLab.Application.Features.TradingSessions.Commands.CreateTradingSession;

namespace TradingAnalyticsLab.UnitTests.Application;

public class CreateTradingSessionCommandHandlerTests
{
    [Fact]
    public async Task Should_Create_Trading_Session()
    {
        var handler = new CreateTradingSessionCommandHandler();

        var command = new CreateTradingSessionCommand(
            Guid.NewGuid(),
            DateOnly.FromDateTime(DateTime.Today),
            "Good trading day");

        var result = await handler.Handle(
            command,
            CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result.SessionId);
    }
}