namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

public class ResourceRepository : IResourceRepository
{
    private readonly EventManagementDbContext _context;

    public ResourceRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddResourceAsync(Resource resource)
    {
        await _context.Resources.AddAsync(resource);
        await _context.SaveChangesAsync();
        return resource.id;
    }

    public async Task<Resource?> GetResourceByIdAsync(Guid id)
    {
        return await _context.Resources
            .FirstOrDefaultAsync(r => r.id == id);
    }
}
