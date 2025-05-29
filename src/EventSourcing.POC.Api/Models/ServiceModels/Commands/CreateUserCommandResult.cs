namespace EventSourcing.POC.Api.Models.ServiceModels.Commands
{
    public record CreateUserCommandResult(
        Guid UserId,
        string Username,
        string Email
    );    
}