using TradingAnalyticsLab.Domain.Common;

namespace TradingAnalyticsLab.Domain.Entities;

public class JournalEntry : AuditableEntity
{
    public Guid EntryId { get; private set; }

    public Guid SessionId { get; private set; }

    public string Content { get; private set; } = string.Empty;

    private JournalEntry()
    {
    }

    public JournalEntry(
        Guid sessionId,
        string content)
    {
        EntryId = Guid.NewGuid();

        SessionId = sessionId;

        Content = content;
    }
}