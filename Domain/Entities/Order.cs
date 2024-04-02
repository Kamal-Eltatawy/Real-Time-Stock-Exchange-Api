using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order 
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } 
        public virtual User User { get; set; }

        public List<OrderStocks>  OrderStocks { get; set; } = new List<OrderStocks>();

    }
}
