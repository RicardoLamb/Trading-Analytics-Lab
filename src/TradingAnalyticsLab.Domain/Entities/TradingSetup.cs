using TradingAnalyticsLab.Domain.Common;

namespace TradingAnalyticsLab.Domain.Entities;

public class TradingSetup
{
    public Guid SetupId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    private TradingSetup()
    {
    }

    public TradingSetup(
        string name,
        string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Setup name is required.");

        SetupId = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}