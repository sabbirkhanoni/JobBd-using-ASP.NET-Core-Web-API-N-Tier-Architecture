using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string FullName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        public string Role { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        [StringLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string? otp { get; set; }

        public DateTime? expiryTime { get; set; }

        public virtual List<Job> Jobs { get; set; }
        public virtual List<Application> Applications { get; set; }

        public User()
        {
            Jobs = new List<Job>();
            Applications = new List<Application>();
        }
    }
}
