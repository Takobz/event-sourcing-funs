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
        var @event = DeserializeByEventType(eventData.EventType, eventData.EventJsonData) ??
            throw new InvalidOperationException($"Couldn't deserialize event data: {eventData} from even store.");

        @event.Reconstruct(
            eventData.AggregateId,
            eventData.EventId,
            eventData.EventTimeStamp,
            eventData.EventType
        );

        return @event;
    }

    private static Event? DeserializeByEventType(
        string eventType,
        string data
    )
    {
        return eventType switch
        {
            EventTypes.UserCreated => JsonSerializer.Deserialize<UserCreatedEvent>(data),
            EventTypes.CartCreated => JsonSerializer.Deserialize<CartCreatedEvent>(data),
            _ => throw new InvalidOperationException($"Event type: {eventType} not supported."),
        };
    }
}