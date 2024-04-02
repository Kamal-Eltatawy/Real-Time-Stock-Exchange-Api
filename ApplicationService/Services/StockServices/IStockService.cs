using Domain.DTO;
using Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationService.Services.StockServices
{

    public interface IStockService
    {
        public Task< List<StockResponseDTO> >GetAllStock();
        public Task< List<StockResponseDTO> >GetAllStock(Expression<Func<Stock, bool>> expression);

        public Task<bool> AnyAsync(Expression<Func<Stock, bool>> expression);

    }
}
