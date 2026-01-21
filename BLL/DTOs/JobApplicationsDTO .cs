using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class JobApplicationsDTO : JobDTO
    {
        public List<ApplicationUserDTO> Applications { get; set; }

        public JobApplicationsDTO()
        {
            Applications = new List<ApplicationUserDTO>();
        }
    }
}
