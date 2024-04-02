using Domain.DTO;

namespace ApplicationService.Services.HistoricalServices
{
    public interface IHistoricalStockServices
    {
        public Task<List<StockHistoryResponseDto>> GetHistoricalData(string symbol);

    }
}
