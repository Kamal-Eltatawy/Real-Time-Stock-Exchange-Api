namespace Domain.DTO
{
    public class StockResponseDTO
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public DateTime TimeStamp { get; set; } 
    }
}
