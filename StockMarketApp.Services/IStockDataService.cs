using StockMarketApp.DTO;

namespace StockMarketApp.Services;

public interface IStockDataService
{
    public Task<IntradayResponseDTO?> GetIntradayDataAsync(string symbol, string interval = "5min");
}