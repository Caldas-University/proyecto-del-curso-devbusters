namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IRolePermissionRepository
{
    Task<Guid> AddRolePermissionAsync(RolePermission rolePermission);
    Task<RolePermission> GetRolePermissionById(Guid id);
}