using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Application
    {
        public int Id { get; set; }

        public DateTime AppliedDate { get; set; }

        public string? Status { get; set; }

        [ForeignKey("Job")]
        public int? JobId { get; set; }

        [ForeignKey("JobSeeker")]
        public int? JobSeekerId { get; set; }

        public virtual Job Job { get; set; }
        public virtual User JobSeeker { get; set; }
    }
}
