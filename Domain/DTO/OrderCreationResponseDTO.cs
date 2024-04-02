
namespace Domain.DTO
{
    public class OrderCreationResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public string Type { get; set; }

        public string Symbol { get; set; }





    }
}
