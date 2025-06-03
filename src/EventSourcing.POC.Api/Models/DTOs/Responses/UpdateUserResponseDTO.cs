using System.Text.Json.Serialization;

namespace EventSourcing.POC.Api.Models.DTOs.Responses
{
    public record UpdateUserResponseDTO(
        [property: JsonPropertyName("user_id")] Guid UserId,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("email")] string Email
    );
}