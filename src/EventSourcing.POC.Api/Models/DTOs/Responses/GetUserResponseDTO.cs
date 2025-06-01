using System.Text.Json.Serialization;

namespace EventSourcing.POC.Api.Models.DTOs.Responses
{
    public record GetUserResponseDTO(
        [property: JsonPropertyName("user_id")] string UserId,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("email")] string Email
    );
}