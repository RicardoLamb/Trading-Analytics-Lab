namespace TradingAnalyticsLab.Domain.Entities;

public class JournalEntry
{
    public Guid EntryId { get; private set; }

    public Guid SessionId { get; private set; }

    public string Content { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

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

        CreatedAt = DateTime.UtcNow;
    }
}