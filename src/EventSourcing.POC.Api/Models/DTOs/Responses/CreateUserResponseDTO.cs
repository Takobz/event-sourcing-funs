using System.Text.Json.Serialization;

namespace EventSourcing.POC.Api.Models.DTOs.Responses
{
    public record CreateUserResponseDTO(
        [property: JsonPropertyName("user_id")] Guid UserId,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("email")] string Email
    );    
}