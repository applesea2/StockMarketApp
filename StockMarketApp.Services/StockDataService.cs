﻿using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockMarketApp.DTO;

namespace StockMarketApp.Services;

public class StockDataService : IStockDataService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public StockDataService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task<IntradayResponseDTO?> GetIntradayDataAsync(string symbol, string interval = "5min")
    {
        string apiKey = _configuration["StockMarketApp:ApiKey"];
        string QUERY_URL =
            $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey={apiKey})";
            
        var json = await _httpClient.GetAsync(QUERY_URL);
        if (!json.IsSuccessStatusCode) return null;
        var response = JsonSerializer.Deserialize<IntradayResponseDTO>(json.Content.ReadAsStringAsync().Result);
        
        var timeSeriesKey = response?.AdditionalData.Keys?.FirstOrDefault(k => k.Contains("TimeSeries"));
        if (timeSeriesKey != null && response != null && response.AdditionalData.TryGetValue(timeSeriesKey, out var timeSeriesElement))
        {
            var timeSeriesDict = JsonSerializer.Deserialize<Dictionary<string, TimeSeriesEntry>>(timeSeriesElement.GetRawText());
            response.TimeSeries = timeSeriesDict;
        }
        
        return response;
    }
}