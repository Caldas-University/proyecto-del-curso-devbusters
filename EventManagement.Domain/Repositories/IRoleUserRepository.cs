namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IRoleUserRepository
{
    Task<Guid> AssignRoleUserAsync(RoleUser roleUser);
    Task<RoleUser> GetRoleUserByIdAsync(Guid id);
    Task<IEnumerable<RoleUser>> GetAllRoleUsersAsync();
}