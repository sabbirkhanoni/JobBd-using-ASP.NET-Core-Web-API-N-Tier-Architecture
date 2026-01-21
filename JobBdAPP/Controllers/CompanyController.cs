using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBdAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyService service;

        public CompanyController(CompanyService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(CompanyDTO c)
        {
            var res = service.Create(c);
            if (res) return Ok(res);
            return BadRequest(res);
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data != null) return Ok(data);
            return NotFound("Company Not Found");
        }

        [HttpPut("update")]
        public IActionResult Update(CompanyDTO c)
        {
            var res = service.Update(c);
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

        [HttpGet("search")]
        public IActionResult Search(string text)
        {
            return Ok(service.SearchCompany(text));
        }

        [HttpGet("all/jobs")]
        public IActionResult AllWithJobs()
        {
            return Ok(service.GetWithJobs());
        }

        [HttpGet("highest-job-posted")]
        public IActionResult HighestJobPosted()
        {
            return Ok(service.GetCompanyWithHighestJobPosted());
        }

        [HttpGet("company-open-close-jobs-count/{id}")]
        public IActionResult GetOpenClosedJobs(int id)
        {
            Dictionary<string, int> result =
                service.GetCompanyOpenClosedJobCount(id);

            return Ok(result);
        }

        [HttpGet("with-open-jobs")]
        public IActionResult CompaniesWithOpenJobs()
        {
            return Ok(service.GetCompaniesWithOpenJobs());
        }

        [HttpGet("with-closed-jobs")]
        public IActionResult CompaniesWithClosedJobs()
        {
            return Ok(service.GetCompaniesWithClosedJobs());
        }
        
    }
}
