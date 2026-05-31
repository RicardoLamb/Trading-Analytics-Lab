using TradingAnalyticsLab.Application.Features.Analytics.Queries.GetSessionPerformance;

namespace TradingAnalyticsLab.UnitTests.Application;

public class GetSessionPerformanceQueryHandlerTests
{
    [Fact]
    public async Task Should_Return_Session_Performance()
    {
        var handler = new GetSessionPerformanceQueryHandler();

        var query = new GetSessionPerformanceQuery(
            Guid.NewGuid());

        var result = await handler.Handle(
            query,
            CancellationToken.None);

        Assert.Equal(2, result.TotalTrades);

        Assert.Equal(10, result.NetResult);

        Assert.Equal(50, result.WinRate);
    }
}