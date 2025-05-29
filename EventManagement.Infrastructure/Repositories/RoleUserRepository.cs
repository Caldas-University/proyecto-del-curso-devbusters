namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using EventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class RoleUserRepository : IRoleUserRepository
{
    private readonly EventManagementDbContext _context;

    public RoleUserRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AssignRoleUserAsync(RoleUser roleUser)
    {
        await _context.RoleUsers.AddAsync(roleUser);
        await _context.SaveChangesAsync();
        return roleUser.id;
    }

    public async Task<RoleUser> GetRoleUserByIdAsync(Guid id)
    {
        return await _context.RoleUsers.FindAsync(id);
    }

    public async Task<IEnumerable<RoleUser>> GetAllRoleUsersAsync()
    {
        return await _context.RoleUsers.ToListAsync();
    }
}