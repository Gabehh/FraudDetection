using FraudDetection.Models;

namespace FraudDetection.Strategies;

public interface IFraudValidationStrategy
{
    bool IsFraudulent(Order order1, Order order2);
}
