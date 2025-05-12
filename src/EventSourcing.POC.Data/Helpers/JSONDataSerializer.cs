using System.Text.Json;
using EventSourcing.POC.Data.DataModels;
using EventSourcing.POC.Domain.Events;

namespace EventSourcing.POC.Data.Helpers;

public interface IJSONDataSerializer
{
    T DeserializeToObject<T>(string eventType, string data) where T : EventJSONData;
    string SerializeToString<T>(T @object) where T: Event;
}

public class JSONDataSerializer : IJSONDataSerializer
{
    public T DeserializeToObject<T>(string eventType, string data) where T : EventJSONData
    {
        return JsonSerializer.Deserialize<T>(data) ??
            throw new InvalidOperationException($"Failed to deserialize data: {data} to event type: {eventType}");
    }

    public string SerializeToString<T>(T @object) where T : Event 
    {
        return JsonSerializer.Serialize(@object);
    }
}