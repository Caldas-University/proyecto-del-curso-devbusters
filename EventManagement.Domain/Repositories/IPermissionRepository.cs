namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IPermissionRepository
{
    Task<Guid> AddPermissionAsync(Permission permission);
    Task<Permission> GetPermissionByIdAsync(Guid id);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync();
}