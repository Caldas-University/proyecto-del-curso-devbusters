namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class RoleUserServiceApp : IRoleUserServiceApp
{
    private readonly IRoleUserRepository _roleUserRepository;

    public RoleUserServiceApp(IRoleUserRepository roleUserRepository)
    {
        _roleUserRepository = roleUserRepository;
    }

    public async Task<Guid> AssignRoleUserAsync(RoleUser roleUser)
    {
        if (roleUser == null)
        {
            throw new ArgumentNullException(nameof(roleUser));
        }

        var createdRoleUserId = await _roleUserRepository.AssignRoleUserAsync(roleUser);
        return createdRoleUserId;
    }

    public async Task<RoleUser> GetRoleUserByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid role user ID", nameof(id));
        }

        var roleUserEntity = await _roleUserRepository.GetRoleUserById(id);
        if (roleUserEntity == null)
        {
            throw new KeyNotFoundException($"Role user with ID {id} not found");
        }

        return roleUserEntity;
    }

    public async Task<IEnumerable<RoleUser>> GetAllRoleUsersAsync()
    {
        var roleUsers = await _roleUserRepository.GetAllRoleUsersAsync();
        if (roleUsers == null || !roleUsers.Any())
        {
            throw new KeyNotFoundException("No role users found");
        }

        return roleUsers;
    }
}