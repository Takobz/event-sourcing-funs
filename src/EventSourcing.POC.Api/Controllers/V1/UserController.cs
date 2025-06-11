using EventSourcing.POC.Api.Mappers;
using EventSourcing.POC.Api.Models.DTOs.Requests;
using EventSourcing.POC.Api.Models.DTOs.Responses;
using EventSourcing.POC.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using EventSourcing.POC.Api.Models.ServiceModels.Queries;

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

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(GetUserResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await userService.GetUserAsync(new GetUserQuery(
                userId
            ));

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(UpdateUserResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(
            Guid userId,
            [FromBody] UpdateUserRequestDTO request
        )
        {
            
            return Ok(new UpdateUserResponseDTO(
                Guid.NewGuid(),
                string.Empty,
                string.Empty
            ));
        }
    }   
}