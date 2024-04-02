using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainServices.Repository;
using DomainServices.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationService.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IRepository<Order> orderRepository;
        private IRepository<OrderStocks> orderStocksRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            orderRepository = unitOfWork.GetRepository<Order>();
            orderStocksRepository = unitOfWork.GetRepository<OrderStocks>();
        }

        public async Task<OrderCreationResponseDTO> CreateAsync(OrderRequestDTO orderRequestDTO)
        {
            var order = mapper.Map<Order>(orderRequestDTO);
            order.UserId = httpContextAccessor?.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var orderStocks = mapper.Map<OrderStocks>(orderRequestDTO);

            order.OrderStocks.Add(orderStocks);

            await orderRepository.AddAsync(order);


            var rowCount = await unitOfWork.SaveChangesAsync();
            if (rowCount > 0)
            {
                return new OrderCreationResponseDTO
                {
                    IsSuccess = true,
                    Message = "saved Succsefuly ",
                    OrderID = order.Id,
                    Quantity = orderStocks.Quantity,
                    Symbol = orderStocks.StockSymbol,
                    Type = orderRequestDTO.Type.ToString(),
                };
            }

            return new OrderCreationResponseDTO
            {
                IsSuccess = false,
                Message = "Faild To Save ",
                OrderID = 0,
                Quantity = orderRequestDTO.Quantity,
                Symbol = orderRequestDTO.Symbol,
                Type = orderRequestDTO.Type.ToString(),
            };

        }

        public async Task<List<OrderDataResponseDTO>> GetAllOrderAsync()
        {
            return mapper.Map<List<OrderDataResponseDTO>>(await orderStocksRepository.GetAllIncludingAsync(
                i => i.Order,
                i => i.Stock
            ));
        }

       
    }

}

