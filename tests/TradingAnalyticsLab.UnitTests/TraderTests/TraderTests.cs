using TradingAnalyticsLab.Domain.Common;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.UnitTests;

public class TraderTests
{
    [Fact]
    public void Should_Create_Trader_When_Data_Is_Valid()
    {
        var trader = new Trader(
            "Ricardo Lamb",
            "ricardo@email.com");

        Assert.NotNull(trader);
    }

    [Fact]
    public void Should_Throw_Exception_When_Name_Is_Empty()
    {
        Assert.Throws<DomainException>(() =>
            new Trader(
                "",
                "ricardo@email.com"));
    }
}