using System.Text.Json.Serialization;

namespace EventSourcing.POC.Api.Models.DTOs.Requests
{
    public record CreateUserRequestDTO(
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("email")] string Email
    );
}