using TradingAnalyticsLab.Domain.Common;

namespace TradingAnalyticsLab.Domain.Entities;

public class Trader : AuditableEntity
{
    public Guid TraderId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    private Trader()
    {
    }

    public Trader(string name, string email)
    {
        TraderId = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}