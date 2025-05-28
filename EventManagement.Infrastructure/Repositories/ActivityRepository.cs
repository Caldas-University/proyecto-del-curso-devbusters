namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

public class ActivityRepository : IActivityRepository
{
    private readonly EventManagementDbContext _context;

    public ActivityRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Activity activity)
    {
        await _context.Activities.AddAsync(activity);
        await _context.SaveChangesAsync();
        return activity.id;
    }

    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        return await _context.Activities
            .FirstOrDefaultAsync(a => a.id == id);
    }
}
