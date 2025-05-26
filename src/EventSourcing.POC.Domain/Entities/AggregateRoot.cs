using EventSourcing.POC.Domain.Events;

namespace EventSourcing.POC.Domain.Entities
{
    /// <summary>
    /// Base class that helps construct an entity.
    /// </summary>
    public abstract class AggregateRoot
    {
        /*
         An aggregate should be able to:
            - Have a list of events yet to be committed
            - Apply a list of events to get current state of aggregate.
            - add event to uncommitted events.
        */

        /// <summary>
        /// Domain events yet to be committed the event store.
        /// </summary>
        private readonly List<Event> _uncommittedEvents = [];

         /// <summary>
        /// Interface to expose uncommitted events.
        /// </summary>
        public IReadOnlyList<Event> UncommittedEvents => _uncommittedEvents.AsReadOnly();

        /// <summary>
        /// Add events to be committed to the event store
        /// </summary>
        /// <param name="event">Uncommitted event to be added to a list of other uncomitted evnets</param>
        public void AddEvent(Event @event)
        {
            _uncommittedEvents.Add(@event);
        }

        /// <summary>
        /// Given a list of events I should reconstruct the aggregate.
        /// </summary>
        /// <param name="events">List of events, typically from event store.</param>
        public void LoadFromHistory(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        /// <summary>
        /// Aggregate will implement this for it's events. 
        /// </summary>
        /// <param name="event">Event to be applied to mutate state</param>
        protected abstract void ApplyEvent(Event @event);
    }    
}