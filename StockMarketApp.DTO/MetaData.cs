using System.Text.Json.Serialization;

namespace StockMarketApp.DTO;

public class MetaData
{
    [JsonPropertyName("1. Information")]
    public string? Information { get; set; }

    [JsonPropertyName("2. Symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("3. Last Refreshed")]
    public string? LastRefreshed { get; set; }

    [JsonPropertyName("4. Interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("5. Output Size")]
    public string? OutputSize { get; set; }

    [JsonPropertyName("6. Time Zone")]
    public string? TimeZone { get; set; }
}
