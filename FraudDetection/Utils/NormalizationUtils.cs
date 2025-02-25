namespace FraudDetection.Utils;

public static class NormalizationUtils
{
    public static string NormalizeEmail(string email)
    {
        email = email.ToLower();
        var parts = email.Split('@');
        var localPart = parts[0].Replace(".", "");
        localPart = localPart.Split('+')[0];
        return $"{localPart}@{parts[1]}";
    }

    public static string NormalizeAddress(string street, string city, string state)
    {
        street = street.Replace("St.", "Street").Replace("Rd.", "Road");
        city = city.ToLower();
        state = state.ToUpper() switch
        {
            "IL" => "Illinois",
            "CA" => "California",
            "NY" => "New York",
            _ => state
        };
        return $"{street}, {city}, {state}";
    }
}