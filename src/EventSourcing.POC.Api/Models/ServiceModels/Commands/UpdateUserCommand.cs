namespace EventSourcing.POC.Api.Models.ServiceModels.Commands
{ 
    public record UpdateUserCommand(
        Guid UserId,
        string Email
    );
}