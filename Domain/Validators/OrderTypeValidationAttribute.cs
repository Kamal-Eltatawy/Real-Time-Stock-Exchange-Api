using Domain.Const;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validators
{
    public class OrderTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string type = value.ToString().ToLower();
                if (Enum.TryParse(type, ignoreCase:true,out OrderType orderType))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Invalid order type.");
        }
    }
}
