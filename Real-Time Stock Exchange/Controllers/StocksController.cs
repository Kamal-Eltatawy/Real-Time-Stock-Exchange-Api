using ApplicationService.Services.HistoricalServices;
using ApplicationService.Services.StockServices;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Real_Time_Stock_Exchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly IStockService stockService;
        private readonly IHistoricalStockServices historicalStockServices;

        public StocksController(IStockService stockService, IHistoricalStockServices historicalStockServices)
        {
            this.stockService = stockService;
            this.historicalStockServices = historicalStockServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<StockResponseDTO>>> GetAllStocks()
        {
            return Ok(await stockService.GetAllStock());

        }
        [HttpGet("{symbol}/history")]
        public async Task<ActionResult<List<StockHistoryResponseDto>>> GetHistoricalData(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                return BadRequest("Stock symbol is required.");
            }
            if (!stockService.AnyAsync(i => i.Symbol == symbol).Result)
            {
                return NotFound("Stock Symbol is Not Founded.");

            }
            return await historicalStockServices.GetHistoricalData(symbol);


        }

    }
}
