namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IRoleUserRepository
{
    Task<Guid> AddRoleUserAsync(RoleUser roleUser);
    Task<RoleUser> GetRoleUserByIdAsync(Guid id);
    Task<IEnumerable<RoleUser>> GetAllRoleUsersAsync();
    Task UpdateRoleUserAsync(RoleUser roleUser);
    Task DeleteRoleUserAsync(Guid id);
    Task AssignRoleToUserAsync(Guid userId, Guid roleId);
    Task ChangeRoleForUserAsync(Guid userId, Guid roleId);
}