using TradingAnalyticsLab.Domain.Entities;
using TradingAnalyticsLab.Domain.Enums;

namespace TradingAnalyticsLab.UnitTests;

public class TradeTests
{
    [Fact]
    public void Should_Be_Winner_When_NetResult_Is_Positive()
    {
        var trade = new Trade(
            Guid.NewGuid(),
            "WIN",
            TradeDirection.Buy,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(5),
            100,
            80,
            1);

        Assert.True(trade.IsWinner);
    }

    [Fact]
    public void Should_Be_Loser_When_NetResult_Is_Negative()
    {
        var trade = new Trade(
            Guid.NewGuid(),
            "WIN",
            TradeDirection.Buy,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(5),
            -100,
            -120,
            1);

        Assert.True(trade.IsLoser);
    }
}