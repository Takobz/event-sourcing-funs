using EventSourcing.POC.Api.Models.DTOs.Requests;
using EventSourcing.POC.Api.Models.DTOs.Responses;
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
        [ProducesResponseType(typeof(CreateUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserRequestDTO request
        )
        {
            var result = await Task.FromResult(new CreateUserResponseDTO(
                Guid.NewGuid(),
                string.Empty,
                string.Empty
            ));
            
            return Ok(result);
        }
    }   
}