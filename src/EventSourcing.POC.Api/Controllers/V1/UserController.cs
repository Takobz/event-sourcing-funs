using EventSourcing.POC.Api.Mappers;
using EventSourcing.POC.Api.Models.DTOs.Requests;
using EventSourcing.POC.Api.Models.DTOs.Responses;
using EventSourcing.POC.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace EventSourcing.POC.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController(
        IUserService userService
    ) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserRequestDTO request
        )
        {
            var command = request.DtoToCommand();
            var commandResult = await userService.CreateUserAsync(command);
            var result = commandResult.CommandResultToDto();
            return Ok(result);
        }
    }   
}