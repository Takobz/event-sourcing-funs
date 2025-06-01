using EventSourcing.POC.Api.Models.DTOs.Requests;
using EventSourcing.POC.Api.Models.DTOs.Responses;
using EventSourcing.POC.Api.Models.ServiceModels.Commands;
using EventSourcing.POC.Api.Models.ServiceModels.Queries;
using EventSourcing.POC.Domain.Entities;

namespace EventSourcing.POC.Api.Mappers
{
    public static class UserMapper
    {
        public static CreateUserCommand DtoToCommand(this CreateUserRequestDTO dto)
        {
            return new CreateUserCommand(
                dto.Username,
                dto.Email
            );
        }

        public static CreateUserCommandResult EntityToCommandResult(this UserEntity user)
        {
            return new CreateUserCommandResult(
                user.Id,
                user.Username,
                user.Email
            );
        }

        public static CreateUserResponseDTO CommandResultToDto(this CreateUserCommandResult result)
        {
            return new CreateUserResponseDTO(
                result.UserId,
                result.Username,
                result.Email
            );
        }

        public static GetUserQueryResult EntityToQueryResult(this UserEntity user)
        {
            return new GetUserQueryResult(
                user.Id,
                user.Username,
                user.Email
            );
        }
    }    
}