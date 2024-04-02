using Domain.DTO;
using Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationService.Services.OrderServices
{
    public interface IOrderServices
    {
        public Task<List<OrderDataResponseDTO>> GetAllOrderAsync();

        public Task<OrderCreationResponseDTO> CreateAsync(OrderRequestDTO orderRequestDTO);

    }
}
