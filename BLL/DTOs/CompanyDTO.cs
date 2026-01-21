using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class CompanyDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Company Name is Required")]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int OwnerId { get; set; }
    }
}
