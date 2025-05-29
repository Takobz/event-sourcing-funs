using EventSourcing.POC.Api.Mappers;
using EventSourcing.POC.Api.Models.ServiceModels.Commands;
using EventSourcing.POC.Domain.Entities;
using EventSourcing.POC.Domain.Interfaces;

namespace EventSourcing.POC.Api.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResult> CreateUserAsync(CreateUserCommand command);
    }

    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<CreateUserCommandResult> CreateUserAsync(CreateUserCommand command)
        {
            var user = UserEntity.CreateUser(command.Username, command.Email);
            var createdUser = await userRepository.SaveAsync(user);
            return createdUser.EntityToCommandResult();
        }
    }    
}