using EventSourcing.POC.Domain.Events;

namespace EventSourcing.POC.Domain.Interfaces
{
    public interface IEventsRepository
    {
        public Task<UserCreatedEvent> CreateUserAsync();
    }    
}