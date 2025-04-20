using System.Text.Json;
using System.Text.Json.Serialization;

namespace StockMarketApp.DTO;

public class IntradayResponseDTO
{
    [JsonPropertyName("Meta Data")]
    public MetaData? MetaData { get; set; }
    
    // This will hold the actual time series data directly, based on the interval.
    [JsonPropertyName("Time Series")]
    public Dictionary<string, TimeSeriesEntry>? TimeSeries { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}