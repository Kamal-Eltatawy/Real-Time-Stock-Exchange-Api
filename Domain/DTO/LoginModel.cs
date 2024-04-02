using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
