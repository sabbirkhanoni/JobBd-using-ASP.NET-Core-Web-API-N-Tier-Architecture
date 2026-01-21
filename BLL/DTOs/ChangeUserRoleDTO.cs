using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ChangeUserRoleDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [RegularExpression("Admin|Employee|JobSeeker",
            ErrorMessage = "Role must be Admin, Employee, or JobSeeker")]
        public string NewRole { get; set; }
    }
}
