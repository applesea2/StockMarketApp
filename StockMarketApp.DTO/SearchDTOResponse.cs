using System.Text.Json.Serialization;

namespace StockMarketApp.DTO;

public class SearchDTOResponse
{
    [JsonPropertyName("bestMatches")]
    public List<SearchDTO>? BestMatches { get; set; }
}