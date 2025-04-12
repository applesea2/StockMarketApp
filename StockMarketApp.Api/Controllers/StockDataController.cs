using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StockMarketApp.DTO;
using StockMarketApp.Services;

namespace StockMarketApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        private readonly IStockDataService _stockDataService;
        
        public StockDataController(IStockDataService stockDataService)
        {
            _stockDataService = stockDataService;
        }
        
        [HttpGet("intraday/{symbol}")]
        public async Task<IActionResult?> GetIntradayDataAsync(string symbol,[FromQuery] string interval = "5min")
        {
            var result = await _stockDataService.GetIntradayDataAsync(symbol, interval);
            return Ok(result);
        }

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult?> Search(string keyword)
        {
            var result = await _stockDataService.GetSearchDataAsync(keyword);
            return Ok(result);
        }
    }
}
