namespace TradingAnalyticsLab.Domain.Entities;

public class TradingSession
{
    public Guid SessionId { get; private set; }

    public Guid AccountId { get; private set; }

    public DateOnly TradingDate { get; private set; }

    public string? Notes { get; private set; }

    private TradingSession()
    {
    }

    public TradingSession(
        Guid accountId,
        DateOnly tradingDate,
        string? notes = null)
    {
        SessionId = Guid.NewGuid();
        AccountId = accountId;
        TradingDate = tradingDate;
        Notes = notes;
    }

    public void UpdateNotes(string notes)
    {
        Notes = notes;
    }
}