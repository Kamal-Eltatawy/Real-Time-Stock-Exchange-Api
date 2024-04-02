using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderStocks 
    {

        public int Quantity { get; set; }



        [ForeignKey(nameof(Stock))]
        public string StockSymbol { get; set; }

        public virtual Stock Stock { get; set; }


        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
