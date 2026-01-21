using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Job
    {
        public int Id { get; set; }

        [StringLength(150)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        [StringLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        public decimal Salary { get; set; }

        [StringLength(150)]
        [Column(TypeName = "VARCHAR")]
        public string Location { get; set; }

        public string Status { get; set; }


        [ForeignKey("Company")]
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual List<Application> Applications { get; set; }

        public Job()
        {
            Applications = new List<Application>();
        }
    }
}
