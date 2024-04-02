using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class StockHistoryResponseDto
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Price { get; set; }


    }
}
