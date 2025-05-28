namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

public class ResourceAssignmentRepository : IResourceAssignmentRepository
{
    private readonly EventManagementDbContext _context;

    public ResourceAssignmentRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddResourceAssignmentAsync(ResourceAssignment assignment)
    {
        await _context.ResourceAssignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
        return assignment.id;
    }

    public async Task<ResourceAssignment?> GetResourceAssignmentByIdAsync(Guid id)
    {
        return await _context.ResourceAssignments
            .FirstOrDefaultAsync(a => a.id == id);
    }
}
