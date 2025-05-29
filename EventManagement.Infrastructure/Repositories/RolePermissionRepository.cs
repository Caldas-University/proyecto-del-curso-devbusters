namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using EventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly EventManagementDbContext _context;

    public RolePermissionRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddRolePermissionAsync(RolePermission rolePermission)
    {
        await _context.RolePermissions.AddAsync(rolePermission);
        await _context.SaveChangesAsync();
        return rolePermission.id;
    }

    public async Task<RolePermission> GetRolePermissionById(Guid id)
    {
        return await _context.RolePermissions
            .FirstOrDefaultAsync(rp => rp.id == id);
    }
}