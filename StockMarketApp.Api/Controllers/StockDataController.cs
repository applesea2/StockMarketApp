using Microsoft.AspNetCore.Mvc;

namespace StockMarketApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult SimpleTest()
        {
            return Ok("Works");
        }
        
        [HttpGet("intraday/{symbol}")]
        public IActionResult GetIntradayData(string symbol)
        {
            // Your logic to call Alpha Vantage and return data
            return Ok($"Intraday data for {symbol}"); // Placeholder
        }

        [HttpGet("symbols/search/{keyword}")]
        public IActionResult Search(string keyword)
        {
            return Ok($"Search results for {keyword}"); // Placeholder
        }
        
    }
}
