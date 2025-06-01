namespace EventSourcing.POC.Api.Models.ServiceModels.Queries
{
    public record GetUserQueryResult(
        Guid UserId,
        string Username,
        string Email
    ){};
}
