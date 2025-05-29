namespace EventManagement.Application.Contracts.Services;

using EventManagement.Domain.Entities;

public interface IUserServiceApp
{
    Task<Guid> UserAsync(User userEntity);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
}