using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public string Salary { get; set; }

        public int CompanyId { get; set; }

    }
}
