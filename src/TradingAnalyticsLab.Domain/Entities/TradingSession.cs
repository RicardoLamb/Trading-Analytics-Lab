using TradingAnalyticsLab.Domain.Common;

namespace TradingAnalyticsLab.Domain.Entities;

public class TradingSession : AuditableEntity
{
    public Guid SessionId { get; private set; }

    public Guid AccountId { get; private set; }

    public DateOnly TradingDate { get; private set; }

    public string? Notes { get; private set; }

    private readonly List<Trade> _trades = new();

    public IReadOnlyCollection<Trade> Trades => _trades;    

    private TradingSession()
    {
    }

    public TradingSession(
        Guid accountId,
        DateOnly tradingDate,
        string? notes = null)
    {
        if (accountId == Guid.Empty)
            throw new DomainException("AccountId is required.");
            
        SessionId = Guid.NewGuid();
        AccountId = accountId;
        TradingDate = tradingDate;
        Notes = notes;
    }

    public void UpdateNotes(string notes)
    {
        if (string.IsNullOrWhiteSpace(notes))
            throw new DomainException("Notes cannot be empty.");

        Notes = notes;

        MarkAsUpdated();
    }

    public void AddTrade(Trade trade)
    {
        _trades.Add(trade);

        MarkAsUpdated();
    }    

    public decimal GetNetResult()
    {
        return _trades.Sum(x => x.NetResult);
    }    

    public decimal GetWinRate()
    {
        if (!_trades.Any())
            return 0;

        var winners = _trades.Count(x => x.IsWinner);

        return (decimal)winners / _trades.Count * 100;
    }    
}