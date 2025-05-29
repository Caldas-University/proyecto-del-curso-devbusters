namespace EventManagement.Application.Contracts.Services;

using EventManagement.Domain.Entities;

public interface IPermissionServiceApp
{
    Task<Guid> PermissionAsync(Permission permissionEntity);
    Task<Permission> GetPermissionByIdAsync(Guid id);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync();
}