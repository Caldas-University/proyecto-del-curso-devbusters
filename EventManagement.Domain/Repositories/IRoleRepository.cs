namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IRoleRepository
{
    Task<Guid> AddRoleAsync(Role role);
    Task<Role> GetRoleByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(Guid id);
}
