using TradingAnalyticsLab.Domain.Common;

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
        if (string.IsNullOrWhiteSpace(brokerName))
            throw new DomainException("Broker name is required.");

        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new DomainException("Account number is required.");

        AccountId = Guid.NewGuid();
        TraderId = traderId;
        BrokerName = brokerName;
        AccountNumber = accountNumber;
    }
}