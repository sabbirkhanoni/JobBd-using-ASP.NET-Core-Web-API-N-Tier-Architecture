using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBdAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        JobService service;

        public JobController(JobService service)
        {
            this.service = service;
        }

        //CRUD Controllers

        [HttpPost("create")]
        public IActionResult Create(JobDTO j)
        {
            var res = service.Create(j);
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
            return Ok(service.Get(id));
        }

        [HttpPut("update")]
        public IActionResult Update(JobDTO j)
        {
            var res = service.Update(j);
            if (res) return Ok(res);
            return BadRequest(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res) return Ok(res);
            return BadRequest(res);
        }


        //Feature Controller

        [HttpGet("recommend/{userId}")]
        public IActionResult RecommendJobs(int userId)
        {
            List<JobDTO> recommendedJobs = service.GetRecommendedJobs(userId);
            return Ok(recommendedJobs);
        }

        [HttpGet("search")]
        public IActionResult Search(string? keyword, string? location, string? status)
        {
            return Ok(service.Search(keyword, location, status));
        }

        [HttpGet("location/{location}")]
        public IActionResult GetJobsByLocation(string location)
        {
            var data = service.GetJobsByLocation(location);
            return Ok(data);
        }

        [HttpGet("search/title")]
        public IActionResult SearchByTitle( string title)
        {
            var data = service.SearchByTitle(title);
            return Ok(data);
        }

        [HttpGet("search/description")]
        public IActionResult SearchByDescription(string keyword)
        {
            var data = service.SearchByDescription(keyword);
            return Ok(data);
        }


        [HttpGet("recent")]
        public IActionResult RecentJobs()
        {
            return Ok(service.GetRecentJobs());
        }


        [HttpPut("status/{id}")]
        public IActionResult UpdateJobStatus(int id, string newStatus)
        {
            var res = service.UpdateJobStatus(id, newStatus);
            if (res) return Ok(res);
            return NotFound("Job not found");
        }

        [HttpGet("status/{status}")]
        public IActionResult GetJobsByStatus(string status)
        {
            var data = service.GetJobsByStatus(status);
            return Ok(data);
        }

        [HttpGet("salary")]
        public IActionResult GetJobsBySalaryRange(decimal min, decimal max)
        {
            var data = service.GetJobsBySalaryRange(min, max);
            return Ok(data);
        }

        

        [HttpGet("company/{companyId}")]
        public IActionResult GetJobsByCompany(int companyId)
        {
            var data = service.GetJobsByCompany(companyId);
            return Ok(data);
        }

        

        [HttpGet("highest-salary")]
        public IActionResult GetHighestSalaryJobs(int count)
        {
            var data = service.GetHighestSalaryJobs(count);
            return Ok(data);
        }

        [HttpGet("{jobId}/applications/count")]
        public IActionResult GetApplicationCount(int jobId)
        {
            var count = service.GetApplicationCount(jobId);
            return Ok(new { JobId = jobId, ApplicationCount = count });
        }

        [HttpGet("most-popular")]
        public IActionResult GetJobsWithMostApplications()
        {
            var data = service.GetJobsWithMostApplications();
            return Ok(data);
        }


        [HttpGet("{jobId}/applications/list")]
        public IActionResult GetJobApplications(int jobId)
        {
            var data = service.GetJobApplications(jobId);
            return Ok(data);
        }

        [HttpGet("total-count")]
        public IActionResult GetTotalJobCount()
        {
            var count = service.GetTotalJobCount();
            return Ok(new { TotalJobs = count });
        }
    }
}
