using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CompanyJobDTO : CompanyDTO
    {
        public List<JobDTO> Jobs { get; set; }

        public CompanyJobDTO()
        {
            Jobs = new List<JobDTO>();
        }
    }
}
