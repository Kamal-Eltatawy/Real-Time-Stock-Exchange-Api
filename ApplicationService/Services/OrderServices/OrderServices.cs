using ApplicationService.Services.StockServices;
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
        private readonly IStockService stockService;

        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IStockService stockService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.stockService = stockService;
            orderRepository = unitOfWork.GetRepository<Order>();
            orderStocksRepository = unitOfWork.GetRepository<OrderStocks>();
        }

        public async Task<OrderCreationResponseDTO> CreateAsync(OrderRequestDTO orderRequestDTO)
        {
            if (!await stockService.AnyAsync(i => i.Symbol == orderRequestDTO.Symbol))
            {
                return new OrderCreationResponseDTO
                {
                    IsSuccess = false,
                    Message = "Stock Symbol IS Not Exsists ",
                    OrderID = 0,
                    Quantity = orderRequestDTO.Quantity,
                    Symbol = orderRequestDTO.Symbol,
                    Type = orderRequestDTO.Type.ToString(),
                };
            }

            var order = mapper.Map<Order>(orderRequestDTO);
            order.UserId = "be9a357a-c31b-4c59-8560-314aa5ac5dc9";
            //order.UserId = httpContextAccessor?.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

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
            var userId = "be9a357a-c31b-4c59-8560-314aa5ac5dc9";
            //var userId = httpContextAccessor?.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            return mapper.Map<List<OrderDataResponseDTO>>(orderStocksRepository.GetAllIncludingAsync(
                i => i.Order,
                i => i.Stock
            ).Result.Where(i => i.Order.UserId == userId));
        }


    }

}

