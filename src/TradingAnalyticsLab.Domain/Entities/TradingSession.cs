using TradingAnalyticsLab.Domain.Common;

namespace TradingAnalyticsLab.Domain.Entities;

public class TradingSession : AuditableEntity
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
}