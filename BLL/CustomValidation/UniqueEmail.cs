using DAL.EF;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL.CustomValidation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Email is required");

            var db = validationContext
                        .GetService<JobBdContext>();

            var email = value.ToString();

            var exists = db.Users.Any(u => u.Email == email);

            if (exists)
                return new ValidationResult("Email already exists");

            return ValidationResult.Success;
        }
    }
}
