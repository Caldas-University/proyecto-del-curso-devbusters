namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Repositories;
using EventManagement.Domain.Entities;

public class RolePermissionServiceApp : IRolePermissionServiceApp
{
    private readonly IRolePermissionRepository _rolePermissionRepository;

    public RolePermissionServiceApp(IRolePermissionRepository rolePermissionRepository)
    {
        _rolePermissionRepository = rolePermissionRepository;
    }

    public async Task<Guid> AddRolePermissionAsync(RolePermission rolePermission)
    {
        if (rolePermission == null)
        {
            throw new ArgumentNullException(nameof(rolePermission));
        }

        var createdRolePermissionId = await _rolePermissionRepository.AddRolePermissionAsync(rolePermission);
        return createdRolePermissionId;
    }

    public async Task<RolePermission> GetRolePermissionByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid role permission ID", nameof(id));
        }

        var rolePermissionEntity = await _rolePermissionRepository.GetRolePermissionById(id);
        if (rolePermissionEntity == null)
        {
            throw new KeyNotFoundException($"Role permission with ID {id} not found");
        }

        return rolePermissionEntity;
    }
}