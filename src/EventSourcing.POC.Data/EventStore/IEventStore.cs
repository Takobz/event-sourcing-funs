using EventSourcing.POC.Data.DataModels;
using EventSourcing.POC.Data.DbContexts;
using EventSourcing.POC.Data.Helpers;
using EventSourcing.POC.Domain.Events;

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
        public IEnumerable<Event> GetEventsAsync(Guid aggregateId)
        {
            /*
            This doesn't seem it will work what if an event is UserCreationEvent ?
            */
            return dbContext.Events.Where(@event => @event.AggregateId == aggregateId)
                .Select(e => 
                    new Event(
                        e.AggregateId,
                        e.EventId,
                        e.EventTimeStamp,
                        e.EventType
                    )
                ).AsEnumerable();
        }

        public async Task SaveEventsAsync(IEnumerable<Event> events)
        {
            foreach(var @event in events)
            {
                await dbContext.Events.AddAsync(new EventData
                {
                    AggregateId = @event.AggregateId,
                    EventType = @event.EventType,
                    /*
                    Not sure if this works but to check out tomz!
                    */
                    Data = dataSerializer.SerializeToString(@event),
                    EventTimeStamp = @event.EventTimeStamp
                });
            }

            throw new NotImplementedException();
        }
    }
}