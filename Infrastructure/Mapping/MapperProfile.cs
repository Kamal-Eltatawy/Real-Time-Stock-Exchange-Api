using AutoMapper;
using Domain.DTO;
using Domain.Entities;

namespace Infrastructure.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterModel, User>().ReverseMap();

            CreateMap<Stock, StockResponseDTO>().ReverseMap();

            CreateMap<HistoricalStock, StockHistoryResponseDto>().ForMember(d => d.Symbol, s => s.MapFrom(d => d.Stock.Symbol)).ReverseMap();

            CreateMap<OrderRequestDTO, Order>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<OrderRequestDTO, OrderStocks>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.StockSymbol, opt => opt.MapFrom(src => src.Symbol)).ReverseMap();

            CreateMap<OrderCreationResponseDTO, Order>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderID))
                .ReverseMap();
            CreateMap<OrderStocks, OrderDataResponseDTO>()
          .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.StockSymbol))
          .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderID))
          .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
          .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Order.Type))
          .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Stock.Name))

              .ReverseMap();


        }

    }
}
