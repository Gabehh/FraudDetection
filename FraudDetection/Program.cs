using FraudDetection.Context;
using FraudDetection.Models;
using FraudDetection.Utils;

namespace FraudDetection;

public static class  Program
{
    static void Main()
    {
        string input = "3\n1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010\n2,1,bugs.1@bunny.com,123 Sesame St.,New York,NY,10011,12345689011\n3,2,bugs@bunny.com,123 Sesame Street,New York,NY,10011,12345689010";
        var orders = ParseOrders(input);
        var fraudDetectionContext = new FraudDetectionContext();
        var fraudulentOrderIds = fraudDetectionContext.GetFraudulentOrders(orders);
        Console.WriteLine("Órdenes fraudulentas: " + string.Join(", ", fraudulentOrderIds));
        Console.ReadKey();
    }

    static List<Order> ParseOrders(string input)
    {
        var orders = new List<Order>();

        var lines = input.Split('\n');
        int N = int.Parse(lines[0]); 

        for (int i = 1; i <= N; i++)
        {
            var parts = lines[i].Split(',');

            var order = new Order
            {
                OrderId = int.Parse(parts[0]),
                DealId = int.Parse(parts[1]),
                Email = parts[2].Trim(),
                StreetAddress = parts[3].Trim(),
                City = parts[4].Trim(),
                State = parts[5].Trim(),
                ZipCode = parts[6].Trim(),
                CreditCard = parts[7].Trim()
            };

            order.Email = NormalizationUtils.NormalizeEmail(order.Email);
            order.StreetAddress = NormalizationUtils.NormalizeAddress(order.StreetAddress, order.City, order.State);
            orders.Add(order);
        }

        return orders;
    }
}