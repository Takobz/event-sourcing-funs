using EventSourcing.POC.Domain.Entities;
using EventSourcing.POC.Domain.Interfaces;
using EventSourcing.POC.Infrastructure.Store;

namespace EventSourcing.POC.Infrastructure.Repositories
{
    public class UserRepository(IEventStore eventStore) : IUserRepository
    {
        private readonly IEventStore _eventStore = eventStore;

        public async Task<UserEntity?> GetUserAsync(Guid userId)
        {
            var events =  _eventStore.GetEventsAsync(userId);
            if (!events.Any()) return null;

            var user = new UserEntity();
            user.LoadFromHistory(events);
            return await Task.FromResult(user); //not ideal
        }

        public async Task<UserEntity> SaveAsync(UserEntity user)
        {
            var uncommittedEvents = user.UncommittedEvents;
            if (uncommittedEvents.Any())
            {
                await _eventStore.SaveEventsAsync(uncommittedEvents);
                // Clear events after saving (you'll need to implement this in AggregateRoot)
            }
            return user;
        }

        public Task<UserEntity> CreateUserAsync(string username, string email)
        {
            // This method should probably be removed from the interface
            // as creation should be handled through domain methods
            throw new NotImplementedException("Use UserEntity.CreateUser() domain method instead");
        }
    }
}