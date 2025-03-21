﻿namespace FraudDetection.Models;

public struct Order
{
    public int OrderId { get; set; }
    public int DealId { get; set; }
    public string Email { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string CreditCard { get; set; }
}
