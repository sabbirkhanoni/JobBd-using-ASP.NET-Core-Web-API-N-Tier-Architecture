using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(150)]
        [Column(TypeName = "VARCHAR")]
        public string CompanyName { get; set; }

        [StringLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Location { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual List<Job> Jobs { get; set; }

        public Company()
        {
            Jobs = new List<Job>();
        }
    }
}
