using TradingAnalyticsLab.Domain.Enums;
using TradingAnalyticsLab.Domain.Common;

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
        if (sessionId == Guid.Empty)
            throw new DomainException("SessionId is required.");

        if (string.IsNullOrWhiteSpace(symbol))
            throw new DomainException("Symbol is required.");

        if (quantity <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        if (exitTime < entryTime)
            throw new DomainException("Exit time cannot be before entry time.");

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