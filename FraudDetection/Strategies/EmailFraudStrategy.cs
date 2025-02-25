using FraudDetection.Models;

namespace FraudDetection.Strategies;

public class EmailFraudStrategy : IFraudValidationStrategy
{
    public bool IsFraudulent(Order order1, Order order2) => order1.Email == order2.Email;
}