using FraudDetection.Models;

namespace FraudDetection.Strategies;

public class AddressFraudStrategy : IFraudValidationStrategy
{
    public bool IsFraudulent(Order order1, Order order2) => order1.StreetAddress == order2.StreetAddress;
}