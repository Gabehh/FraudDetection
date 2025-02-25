namespace FraudDetection.Models;

public class Order
{
    public required int OrderId { get; set; }
    public required int DealId { get; set; }
    public required string Email { get; set; }
    public required string StreetAddress { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string CreditCard { get; set; }
}
