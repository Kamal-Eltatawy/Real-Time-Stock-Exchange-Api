namespace Domain.DTO
{
    public class OrderDataResponseDTO
    {
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public string Type { get; set; }
        public string StockName { get; set; }

        public string Symbol { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
