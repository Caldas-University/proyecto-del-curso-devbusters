namespace EventManagement.Application.Contracts.Services;

using EventManagement.Domain.Entities;

public interface IRolePermissionServiceApp
{
    Task<Guid> AddRolePermissionAsync(RolePermission rolePermission);
    Task<RolePermission> GetRolePermissionByIdAsync(Guid id);
}