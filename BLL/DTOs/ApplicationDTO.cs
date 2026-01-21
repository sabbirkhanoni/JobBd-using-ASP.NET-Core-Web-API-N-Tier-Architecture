
using System;
using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
