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
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException("Journal content is required.");

        EntryId = Guid.NewGuid();

        SessionId = sessionId;

        Content = content;
    }
}