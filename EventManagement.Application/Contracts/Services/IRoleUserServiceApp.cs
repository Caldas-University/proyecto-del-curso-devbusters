namespace EventManagement.Application.Contracts.Services;

using EventManagement.Domain.Entities;

public interface IRoleUserServiceApp
{
    Task<Guid> AssignRoleUserAsync(RoleUser roleUser);
    Task<RoleUser> GetRoleUserByIdAsync(Guid id);
    Task<IEnumerable<RoleUser>> GetAllRoleUsersAsync();
}