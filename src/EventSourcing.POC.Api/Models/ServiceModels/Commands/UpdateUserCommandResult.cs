namespace EventSourcing.POC.Api.Models.ServiceModels.Commands
{ 
    public record UpdateUserCommandResult(
        Guid UserId,
        string Username,
        string Email
    );
}