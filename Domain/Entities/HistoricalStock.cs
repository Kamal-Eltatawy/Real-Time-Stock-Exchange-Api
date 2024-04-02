using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HistoricalStock
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime TimeStamp { get; set; }

        [ForeignKey(nameof(Stock))]

        public string StockSymbol { get; set; }

        public Stock Stock { get; set; }
    }
}
