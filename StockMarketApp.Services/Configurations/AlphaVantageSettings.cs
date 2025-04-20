namespace StockMarketApp.Api.Configurations;

public class AlphaVantageSettings
{
    public const string SectionName = "AlphaVantage";
    
    public string? ApiKey { get; set; }
    
    public string? BaseAddress { get; set; }
}