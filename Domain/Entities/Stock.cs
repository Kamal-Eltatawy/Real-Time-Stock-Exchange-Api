
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Stock 
    {
        [Key,StringLength(maximumLength:15,MinimumLength =2)]
        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual List<HistoricalStock> HistoricalStockData { get; set; }

        public List<OrderStocks> OrderStocks { get; set; }

    }
}
