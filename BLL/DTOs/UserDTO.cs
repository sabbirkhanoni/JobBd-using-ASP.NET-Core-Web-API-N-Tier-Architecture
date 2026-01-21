using BLL.CustomValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "Full Name is required")]

        public string Password { get; set; }

        [RegularExpression("Admin|Employee|JobSeeker", ErrorMessage = "Role must be Admin, Employee, or JobSeeker")]
        public string Role { get; set; }
    }
}
