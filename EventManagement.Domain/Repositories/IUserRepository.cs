namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IUserRepository
{
    Task<Guid> AddUserAsync(User user);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
}