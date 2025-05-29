namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class RoleServiceApp : IRoleServiceApp
{
    private readonly IRoleRepository _roleRepository;

    public RoleServiceApp(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<Guid> RoleAsync(Role roleEntity)
    {
        if (roleEntity == null)
        {
            throw new ArgumentNullException(nameof(roleEntity));
        }

        var createdRoleId = await _roleRepository.AddRoleAsync(roleEntity);
        return createdRoleId;
    }

    public async Task<Role> GetRoleByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid role ID", nameof(id));
        }

        var roleEntity = await _roleRepository.GetRoleByIdAsync(id);
        if (roleEntity == null)
        {
            throw new KeyNotFoundException($"Role with ID {id} not found");
        }

        return roleEntity;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();
        return roles;
    }
}