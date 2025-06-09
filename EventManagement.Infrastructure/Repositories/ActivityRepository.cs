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

    public async Task<IEnumerable<Activity>> GetByLocationAndDateAsync(string location, DateTime date)
    {
        return await _context.Activities
            .Where(a => a.location == location && a.date.Date == date.Date)
            .ToListAsync();
    }


    public async Task<IEnumerable<Activity>> GetByEventIdAsync(Guid eventId)
    {
        return await _context.Activities
            .Where(a => a.eventId == eventId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Activity activity)
    {
        var existing = await _context.Activities.FindAsync(activity.id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Actividad con ID {activity.id} no encontrada.");
        }

        // Como las propiedades son privadas, Entity Framework no puede rastrear los cambios directamente.
        // Así que eliminamos y volvemos a agregar la entidad actualizada.

        _context.Entry(existing).State = EntityState.Detached;
        _context.Activities.Update(activity);

        await _context.SaveChangesAsync();
    }


}
