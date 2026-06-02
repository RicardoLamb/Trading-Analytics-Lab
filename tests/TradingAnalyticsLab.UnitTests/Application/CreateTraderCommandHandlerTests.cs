using Moq;

using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Application.Features.Traders.Commands.CreateTrader;

namespace TradingAnalyticsLab.UnitTests.Application;

public class CreateTraderCommandHandlerTests
{
    [Fact]
    public async Task Should_Create_Trader()
    {
        var repositoryMock =
            new Mock<ITraderRepository>();

        repositoryMock
            .Setup(x => x.ExistsByEmailAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var unitOfWorkMock =
            new Mock<IUnitOfWork>();

        var handler =
            new CreateTraderCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object);

        var command =
            new CreateTraderCommand(
                "Ricardo Lamb",
                "ricardo@email.com");

        var result =
            await handler.Handle(
                command,
                CancellationToken.None);

        Assert.Equal(
            "Ricardo Lamb",
            result.Name);
    }
}