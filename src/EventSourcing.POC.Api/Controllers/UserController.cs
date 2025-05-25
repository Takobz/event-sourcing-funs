using EventSourcing.POC.Api.Models.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.POC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserRequestDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser()
        {
            return Ok();
        }
    }   
}