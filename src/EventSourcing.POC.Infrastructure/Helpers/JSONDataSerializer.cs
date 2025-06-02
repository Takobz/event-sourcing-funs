using System.Text.Json;
using EventSourcing.POC.Data.DataModels;
using EventSourcing.POC.Domain.Events;
using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Infrastructure.Helpers;

public interface IJSONDataSerializer
{
    string SerializeToString<T>(T @object) where T : Event;
    public Event DeserializeDataEventToDomainEvent(EventData eventData); 
}

public class JSONDataSerializer : IJSONDataSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public string SerializeToString<T>(T @object) where T : Event
    {
        EventJSONData eventJSONData = @object.EventType switch
        {
            EventTypes.UserCreated => new UserCreatedJSONData(
                                (@object as UserCreatedEvent)?.Username ?? string.Empty,
                                (@object as UserCreatedEvent)?.Email ?? string.Empty
                            ),
            _ => throw new Exception("Yow yeses this is a lot code haha"),
        };

        return JsonSerializer.Serialize(eventJSONData, _options);
    }

    public Event DeserializeDataEventToDomainEvent(
        EventData eventData
    )
    {
        //This is deserializing eventdata not the whole event.
        //fix this...
        var eventJSONData = DeserializeByEventType(eventData.EventType, eventData.EventJsonData) ??
            throw new InvalidOperationException($"Couldn't deserialize event data: {eventData} from even store.");

        return eventData.EventType switch
        {
            EventTypes.UserCreated => new UserCreatedEvent()
                .Reconstruct(
                    aggregateId: eventData.AggregateId,
                    eventId: eventData.EventId,
                    username: (eventJSONData as UserCreatedJSONData)?.Username ?? string.Empty,
                    email: (eventJSONData as UserCreatedJSONData)?.Email ?? string.Empty,
                    eventTimeStamp: eventData.EventTimeStamp
                ),

            _ => throw new InvalidOperationException($"Event type: {eventData.EventType} with data: {eventData.EventJsonData} is unknown")
        };
    }

    private static EventJSONData? DeserializeByEventType(
        string eventType,
        string data
    )
    {
        return eventType switch
        {
            EventTypes.UserCreated => JsonSerializer.Deserialize<UserCreatedJSONData>(data),
            EventTypes.CartCreated => JsonSerializer.Deserialize<CartCreatedJSONData>(data),
            _ => throw new InvalidOperationException($"Event type: {eventType} not supported."),
        };
    }
}