using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBdAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        ApplicationService service;

        public ApplicationController(ApplicationService service)
        {
            this.service = service;
        }

        //CRUD Controllers

        [HttpPost("apply")]
        public IActionResult Create(ApplicationDTO a)
        {
            var res = service.Create(a);
            if (res) return Ok(res);
            return BadRequest(res);
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var app = service.Get(id);
            if (app != null) return Ok(app);
            return NotFound("Application not found");
        }


        [HttpPut("update")]
        public IActionResult Update(ApplicationDTO a)
        {
            var res = service.UpdateStatus(a);
            if (res) return Ok(res);
            return BadRequest(res);
        }

        //Feature Controllers

        [HttpGet("job-applications-user")]
        public IActionResult GetJobWiseApplications()
        {
            var data = service.GetJobWiseApplications();
            return Ok(data);
        }


        [HttpGet("count/user/{userId}")]
        public IActionResult GetCountByUser(int userId)
        {
            var count = service.GetApplicationCountByUser(userId);
            return Ok(new { UserId = userId, ApplicationCount = count });
        }

        [HttpGet("count/total")]
        public IActionResult GetTotalCount()
        {
            var count = service.GetTotalApplications();
            return Ok(new { TotalApplications = count });
        }


        [HttpPut("update-status/{id}")]
        public IActionResult UpdateStatus(int id, string status)
        {
            var result = service.UpdateApplicationStatus(id, status);
            if (!result)
                return NotFound("Application not found");

            return Ok("Application status updated successfully");
        }


        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status)
        {
            return Ok(service.GetApplicationsByStatus(status));
        }

        //Job Based

        [HttpGet("job/{jobId}")]
        public IActionResult GetByJob(int jobId)
        {
            return Ok(service.GetApplicationsByJob(jobId));
        }


        [HttpGet("job/{jobId}/statistics")]
        public IActionResult GetJobApplicationStatistics(int jobId)
        {
            return Ok(
                service.GetApplicationCountStatisticsOfAJobBasedOnStatus(jobId)
            );
        }

        [HttpGet("most-applied-jobs")]
        public IActionResult GetMostAppliedJobs()
        {
            return Ok(service.GetMostAppliedJobs());
        }
    }
}
