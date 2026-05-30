namespace TradingAnalyticsLab.Domain.Entities;

public class TradingAccount
{
    public Guid AccountId { get; private set; }

    public Guid TraderId { get; private set; }

    public string BrokerName { get; private set; } = string.Empty;

    public string AccountNumber { get; private set; } = string.Empty;

    private TradingAccount()
    {
    }

    public TradingAccount(
        Guid traderId,
        string brokerName,
        string accountNumber)
    {
        AccountId = Guid.NewGuid();
        TraderId = traderId;
        BrokerName = brokerName;
        AccountNumber = accountNumber;
    }
}