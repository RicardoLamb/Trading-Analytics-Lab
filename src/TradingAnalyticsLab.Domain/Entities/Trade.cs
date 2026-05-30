using TradingAnalyticsLab.Domain.Enums;

namespace TradingAnalyticsLab.Domain.Entities;

public class Trade
{
    public Guid TradeId { get; private set; }

    public Guid SessionId { get; private set; }

    public Guid? SetupId { get; private set; }

    public string Symbol { get; private set; } = string.Empty;

    public TradeDirection Direction { get; private set; }

    public DateTime EntryTime { get; private set; }

    public DateTime ExitTime { get; private set; }

    public decimal GrossResult { get; private set; }

    public decimal NetResult { get; private set; }

    public int Quantity { get; private set; }

    private Trade()
    {
    }

    public Trade(
        Guid sessionId,
        string symbol,
        TradeDirection direction,
        DateTime entryTime,
        DateTime exitTime,
        decimal grossResult,
        decimal netResult,
        int quantity,
        Guid? setupId = null)
    {
        TradeId = Guid.NewGuid();

        SessionId = sessionId;
        SetupId = setupId;

        Symbol = symbol;
        Direction = direction;

        EntryTime = entryTime;
        ExitTime = exitTime;

        GrossResult = grossResult;
        NetResult = netResult;

        Quantity = quantity;
    }

    public void AssociateSetup(Guid setupId)
    {
        SetupId = setupId;
    }
}