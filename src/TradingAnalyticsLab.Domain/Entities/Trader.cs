namespace TradingAnalyticsLab.Domain.Entities;

public class Trader
{
    public Guid TraderId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    private Trader()
    {
    }

    public Trader(string name, string email)
    {
        TraderId = Guid.NewGuid();
        Name = name;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }
}