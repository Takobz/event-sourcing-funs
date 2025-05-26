using EventSourcing.POC.Data.DataModels;
using EventSourcing.POC.Data.DbContexts;
using EventSourcing.POC.Data.Helpers;
using EventSourcing.POC.Domain.Events;
using EventSourcing.POC.Domain.ValueObjects;

namespace EventSourcing.POC.Data.EventStore 
{
    public interface IEventStore 
    {
        Task SaveEventsAsync(IEnumerable<Event> events);
        IEnumerable<Event> GetEventsAsync(Guid aggregateId);
    }

    public class EventStore(
        EventSourcingDbContext dbContext,
        IJSONDataSerializer dataSerializer) : IEventStore
    {
        private readonly Dictionary<string, Type> _knownEvents = new()
        {
            {EventTypes.UserCreated, typeof(UserCreatedJSONData)}
        };
        
        public IEnumerable<Event> GetEventsAsync(Guid aggregateId)
    {
            /*
            TODO: test this madness.
            */
            return dbContext.Events.Where(@event => @event.AggregateId == aggregateId)
                .OrderBy(@event => @event.EventTimeStamp)
                .Select(e => dataSerializer.DeserializeDataEventToDomainEvent(e))
                .AsEnumerable();
    }

        public async Task SaveEventsAsync(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                await dbContext.Events.AddAsync(new EventData
                {
                    AggregateId = @event.AggregateId,
                    EventType = @event.EventType,
                    /*
                    Not sure if this works but to check out tomz!
                    */
                    EventJsonData = dataSerializer.SerializeToString(@event),
                    EventTimeStamp = @event.EventTimeStamp
                });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}