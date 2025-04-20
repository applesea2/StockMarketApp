using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StockMarketApp.Api.Configurations;
using StockMarketApp.DTO;

namespace StockMarketApp.Services;

public class StockDataService : IStockDataService
{
    private readonly HttpClient _httpClient;
    private readonly AlphaVantageSettings _alphaVantageSettings;
    public StockDataService(HttpClient httpClient, IOptions<AlphaVantageSettings> alphaVantageSettings)
    {
        _httpClient = httpClient;
        _alphaVantageSettings = alphaVantageSettings.Value ?? throw new ArgumentNullException(nameof(alphaVantageSettings));

        if (string.IsNullOrEmpty(_alphaVantageSettings.ApiKey))
        {
            throw new InvalidOperationException("API key is missing.");
        }
    }
    
    public async Task<IntradayResponseDTO?> GetIntradayDataAsync(string symbol, string interval = "5min")
    {
        string queryUrl =
            $"{_alphaVantageSettings.BaseAddress}/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey={_alphaVantageSettings.ApiKey})";
        
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(queryUrl);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API request failed {response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
            Stream? stream = await response.Content.ReadAsStreamAsync();
            
            IntradayResponseDTO? intradayResponseDTO = JsonSerializer.Deserialize<IntradayResponseDTO>(stream);
        
            string? timeSeriesKey = intradayResponseDTO?.AdditionalData?.Keys?.FirstOrDefault(k => k.Contains("Time Series"));
            
            if (timeSeriesKey != null && intradayResponseDTO != null && 
                intradayResponseDTO.AdditionalData != null && 
                intradayResponseDTO.AdditionalData.TryGetValue(timeSeriesKey, out var timeSeriesElement))
            {
                Dictionary<string, TimeSeriesEntry>? timeSeriesDict = JsonSerializer.Deserialize<Dictionary<string, TimeSeriesEntry>>(timeSeriesElement.GetRawText());
                intradayResponseDTO.TimeSeries = timeSeriesDict;
            }
        
            return intradayResponseDTO;
        }
        catch (HttpRequestException httpEx)
        {
            // Handle exceptions during the HTTP request itself (e.g., network issues, DNS failure, non-success status if using EnsureSuccessStatusCode)
            await Console.Error.WriteLineAsync($"HTTP request error: {httpEx.Message}");
            return null;
        }
        catch (JsonException jsonEx)
        {
            // Handle exceptions during JSON deserialization (e.g., malformed JSON)
            await Console.Error.WriteLineAsync($"JSON deserialization error: {jsonEx.Message}");
            // Consider logging the raw JSON content here if possible (be careful with sensitive data)
            return null;
        }
        catch (Exception ex) // Catch other potential exceptions
        {
            await Console.Error.WriteLineAsync($"An unexpected error occurred: {ex.Message}");
            // Log the full exception details
            return null;
        }
        
    }

    public async Task<SearchDTOResponse?> GetSearchDataAsync(string keyword)
    {
        string queryUrl =
            $"{_alphaVantageSettings.BaseAddress}/query?function=SYMBOL_SEARCH&keywords={keyword}&apikey={_alphaVantageSettings.ApiKey ?? throw new Exception("API Key is missing")}";
        
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(queryUrl);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API request failed {response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
            Stream contentStream = await response.Content.ReadAsStreamAsync();
            SearchDTOResponse? searchResults = JsonSerializer.Deserialize<SearchDTOResponse>(contentStream);
            return searchResults; 
        }
        catch (HttpRequestException httpEx)
        {
            // Handle exceptions during the HTTP request itself (e.g., network issues, DNS failure, non-success status if using EnsureSuccessStatusCode)
            await Console.Error.WriteAsync($"HTTP request error: {httpEx.Message}");
            return null;
        }
        catch (JsonException jsonEx)
        {
            // Handle exceptions during JSON deserialization (e.g., malformed JSON)
            await Console.Error.WriteLineAsync($"JSON deserialization error: {jsonEx.Message}");
            // Consider logging the raw JSON content here if possible (be careful with sensitive data)
            return null;
        }
        catch (Exception ex) // Catch other potential exceptions
        {
            await Console.Error.WriteLineAsync($"An unexpected error occurred: {ex.Message}");
            // Log the full exception details
            return null;
        }
    }
}