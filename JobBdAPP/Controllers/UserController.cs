using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBdAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        // CRUD Controllers

        [HttpPost("create")]
        public IActionResult Create(UserDTO u)
        {
            var res = service.Create(u);
            if (res) return Ok($"User Creted Successfully: {res}");
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
            if(data != null) return Ok(data);
            return NotFound(data);
        }


        [HttpPut("update")]
        public IActionResult Update(UserDTO u)
        {
            var res = service.Update(u);
            if (res) return Ok(res);
            return BadRequest(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res) return Ok(res);
            return NotFound(res);
        }

        //Feature Controller

        [HttpGet("search")]
        public IActionResult SearchByNameOrEmail(string searchText)
        {
            return Ok(service.SearchByNameOrEmail(searchText));
        }


        [HttpGet("role/{role}")]
        public IActionResult GetByRole(string role)
        {
            return Ok(service.GetByRole(role));
        }


        [HttpPut("change-role")]
        public IActionResult ChangeRole(ChangeUserRoleDTO dto)
        {
            var res = service.ChangeUserRole(dto);
            if (res) return Ok(res);
            return NotFound(res);
        }

        [HttpGet("count-by-role")]
        public IActionResult GetUserCount()
        {
            var data = service.GetUserCount();
            if(data != null) return Ok(data);
            return NotFound(data);
        }


    }
}
