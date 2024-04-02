using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Domain.DTO;
using Domain.Entities;
using DomainServices.Repository;
using DomainServices.Services.UnitOfWork;
using System.Linq.Expressions;

namespace ApplicationService.Services.StockServices
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IRepository<Stock> stockRepository;

        public StockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            stockRepository = unitOfWork.GetRepository<Stock>();

        }

        public async Task<bool> AnyAsync(Expression<Func<Stock, bool>> expression)
        {
            return await stockRepository.AnyAsync(expression);
        }

        public async Task<List<StockResponseDTO>> GetAllStock()
        {
            return mapper.Map<List<StockResponseDTO>>(await stockRepository.GetAllAsync());

        }

        public async Task<List<StockResponseDTO>> GetAllStock(Expression<Func<Stock, bool>> expression)
        {
            return mapper.Map<List<StockResponseDTO>>(await stockRepository.GetAllByAsync(expression));
        }

        
    }
}
