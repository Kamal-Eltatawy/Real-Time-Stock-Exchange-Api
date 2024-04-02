using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainServices.Repository;
using DomainServices.Services.UnitOfWork;

namespace ApplicationService.Services.HistoricalServices
{
    public class HistoricalStockServices : IHistoricalStockServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IRepository<HistoricalStock> stockHistoricalRepository;

        public HistoricalStockServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            stockHistoricalRepository = unitOfWork.GetRepository<HistoricalStock>();

        }
        public async Task<List<StockHistoryResponseDto>> GetHistoricalData(string symbol)
        {
            return mapper.Map<List<StockHistoryResponseDto>>(await stockHistoricalRepository.GetAllIncludingAsync(i => i.Stock.Symbol == symbol,e=>e.Stock));
        }
    }
}
