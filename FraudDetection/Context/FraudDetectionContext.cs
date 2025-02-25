using FraudDetection.Models;
using FraudDetection.Strategies;
namespace FraudDetection.Context;

public class FraudDetectionContext
{
    private readonly List<IFraudValidationStrategy> _fraudValidationStrategies;

    public FraudDetectionContext()
    {
        _fraudValidationStrategies =
        [
            new EmailFraudStrategy(),
            new AddressFraudStrategy()
        ];
    }

    public List<int> GetFraudulentOrders(List<Order> orders)
    {
        var fraudulentOrderIds = new List<int>();
        var ordersCount = orders.Count;

        for (int i = 0; i < ordersCount; i++)
        {
            var order1 = orders[i];

            for (int j = i + 1; j < ordersCount; j++)
            {
                var order2 = orders[j];

                if (order1.DealId != order2.DealId) continue;
         
                foreach (var strategy in _fraudValidationStrategies)
                {
                    if (strategy.IsFraudulent(order1, order2))
                    {
                        fraudulentOrderIds.Add(order1.OrderId);
                        fraudulentOrderIds.Add(order2.OrderId);
                        break; 
                    }
                }
                
            }
        }
        return [.. fraudulentOrderIds.Distinct().OrderBy(id => id)];
    }

}