namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class PermissionServiceApp : IPermissionServiceApp
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionServiceApp(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
    }

    public async Task<Guid> PermissionAsync(Permission permissionEntity)
    {
        if (permissionEntity == null)
        {
            throw new ArgumentNullException(nameof(permissionEntity));
        }

        var createdPermissionId = await _permissionRepository.AddPermissionAsync(permissionEntity);
        return createdPermissionId;
    }

    public async Task<Permission> GetPermissionByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid permission ID", nameof(id));
        }

        var permissionEntity = await _permissionRepository.GetPermissionByIdAsync(id);
        if (permissionEntity == null)
        {
            throw new KeyNotFoundException($"Permission with ID {id} not found");
        }

        return permissionEntity;
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        var permissions = await _permissionRepository.GetAllPermissionsAsync();
        return permissions;
    }
}