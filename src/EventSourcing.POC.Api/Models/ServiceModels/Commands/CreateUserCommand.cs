namespace EventSourcing.POC.Api.Models.ServiceModels.Commands
{
    public record CreateUserCommand(
        string Username,
        string Email
    );    
}