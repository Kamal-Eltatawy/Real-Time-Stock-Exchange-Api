using Domain.Const;
using Domain.Entities;
using Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class OrderRequestDTO
    {
        [Required]
        [OrderTypeValidation]
        public string Type { get; set; } 
        [Required]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Symbol Cant be Empity"), StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Symbol cant be less than 2 chars and more than 10 char")]
        public string Symbol { get; set; }

     




    }
}
