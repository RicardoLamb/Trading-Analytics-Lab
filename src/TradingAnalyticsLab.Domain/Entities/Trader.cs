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
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Trader name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Trader email is required.");

        TraderId = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public void Update(
        string name,
        string email)
    {
        Name = name;

        Email = email;

        MarkAsUpdated();
    }
}