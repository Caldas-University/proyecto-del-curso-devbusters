namespace EventManagement.Application.Contracts.Services;

using EventManagement.Domain.Entities;

public interface IRoleServiceApp
{
    Task<Guid> RoleAsync(Role roleEntity);
    Task<Role> GetRoleByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllRolesAsync();
}