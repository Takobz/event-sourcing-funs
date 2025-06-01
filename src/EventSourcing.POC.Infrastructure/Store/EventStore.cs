using EventSourcing.POC.Domain.Events;
using EventSourcing.POC.Data.DbContexts;
using EventSourcing.POC.Data.DataModels;
using EventSourcing.POC.Infrastructure.Helpers;

namespace EventSourcing.POC.Infrastructure.Store
{
    public interface IEventStore
    {
        public Task SaveEventsAsync(IEnumerable<Event> events);
        public IEnumerable<Event> GetEventsAsync(Guid aggregateId);
    }

    public class EventStore(
        IEventSourcingDbContext dbContext,
        IJSONDataSerializer dataSerializer
    ) : IEventStore
    {
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
                    EventJsonData = dataSerializer.SerializeToString(@event),
                    EventTimeStamp = @event.EventTimeStamp
                });
            }

            await dbContext.SaveAsync();
        }
    }
}
