namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using EventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class PermissionRepository : IPermissionRepository
{
    private readonly EventManagementDbContext _context;

    public PermissionRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddPermissionAsync(Permission permission)
    {
        await _context.Permissions.AddAsync(permission);
        await _context.SaveChangesAsync();
        return permission.id;
    }

    public async Task<Permission> GetPermissionByIdAsync(Guid id)
    {
        return await _context.Permissions
            .FirstOrDefaultAsync(p => p.id == id);
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        return await _context.Permissions.ToListAsync();
    }
}
