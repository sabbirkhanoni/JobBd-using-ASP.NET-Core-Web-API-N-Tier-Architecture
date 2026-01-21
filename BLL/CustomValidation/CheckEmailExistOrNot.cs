using DAL.EF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustomValidation
{
    public class CheckEmailExistOrNot : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Email is required");

            var db = validationContext.GetService<JobBdContext>();
            var email = value.ToString();
            var exists = db.Users.Any(u => u.Email == email);

            if (!exists)
                return new ValidationResult("Email not found");

            return ValidationResult.Success;
        }
    }
}
