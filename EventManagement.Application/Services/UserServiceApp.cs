namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class UserServiceApp : IUserServiceApp
{
    private readonly IUserRepository _userRepository;

    public UserServiceApp(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> UserAsync(User userEntity)
    {
        return await _userRepository.AddUserAsync(userEntity);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }
}