using EventSourcing.POC.Domain.Entities;

namespace EventSourcing.POC.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> CreateUserAsync(string username, string email);
        public Task<UserEntity?> GetUserAsync(Guid userId);
        public Task<UserEntity> SaveAsync(UserEntity user);
    }    
}