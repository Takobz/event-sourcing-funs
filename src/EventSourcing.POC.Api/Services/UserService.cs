using EventSourcing.POC.Api.Mappers;
using EventSourcing.POC.Api.Models.ServiceModels.Commands;
using EventSourcing.POC.Api.Models.ServiceModels.Queries;
using EventSourcing.POC.Domain.Entities;
using EventSourcing.POC.Domain.Interfaces;

namespace EventSourcing.POC.Api.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResult> CreateUserAsync(CreateUserCommand command);
        Task<GetUserQueryResult?> GetUserAsync(GetUserQuery query);
        Task<UpdateUserCommandResult> UpdateUserAsync(UpdateUserCommand command);
    }

    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<CreateUserCommandResult> CreateUserAsync(CreateUserCommand command)
        {
            var user = UserEntity.CreateUser(command.Username, command.Email);
            var createdUser = await userRepository.SaveAsync(user);
            return createdUser.EntityToCommandResult();
        }

        public async Task<GetUserQueryResult?> GetUserAsync(GetUserQuery query)
        {
            UserEntity? user = await userRepository.GetUserAsync(query.UserId);
            if (user == null) return default;
            return user.EntityToQueryResult();
        }

        public Task<UpdateUserCommandResult> UpdateUserAsync(UpdateUserCommand command)
        {
            
            throw new NotImplementedException();
        }
    }    
}