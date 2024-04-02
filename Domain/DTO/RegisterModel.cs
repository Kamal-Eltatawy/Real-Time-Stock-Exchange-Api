using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class RegisterModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public List<string> Roles { get; set; }

        [Required, MaxLength(50)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
