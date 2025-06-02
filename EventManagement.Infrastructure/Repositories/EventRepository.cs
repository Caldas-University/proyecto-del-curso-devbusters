namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

public class EventRepository : IEventRepository
{
    private readonly EventManagementDbContext _context;

    public EventRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddEventAsync(Event events)
    {
        await _context.Events.AddAsync(events);
        await _context.SaveChangesAsync();
        return events.id;
    }

    public async Task<Event> GetEventByIdAsync(Guid id)
    {
        return await _context.Events
            .FirstOrDefaultAsync(e => e.id == id);
    }

    public async Task<bool> ExistsConflictingEventAsync(DateTime startDate, DateTime endDate,  Guid? excludeEventId = null)
    {
       return await _context.Events
                // Si excludeEventId no es null, excluye ese Id de la búsqueda
                .Where(e => excludeEventId == null || e.id != excludeEventId)
                .AnyAsync(e =>
                    //  a) e.StartDate cae dentro del rango [startDate, endDate]
                    (e.startDate >= startDate && e.startDate <= endDate)
                    //  b) e.EndDate cae dentro del rango [startDate, endDate]
                    || (e.endDate >= startDate && e.endDate <= endDate)
                    //  c) el rango [startDate, endDate] está completamente dentro de [e.StartDate, e.EndDate]
                    || (startDate >= e.startDate && endDate <= e.endDate)
                );
    }

    public async Task<Event> ModifyEventAsync(Event eventEntity)
        {
            var existing = await _context.Events
                                         .FirstOrDefaultAsync(e => e.id == eventEntity.id);
            if (existing == null)
                return null;

            // Re-asigna sólo las propiedades que consideres modificables:
            existing.name        = eventEntity.name;
            existing.description = eventEntity.description;
            existing.startDate   = eventEntity.startDate;
            existing.endDate     = eventEntity.endDate;
            existing.location    = eventEntity.location;
            existing.type   = eventEntity.type;
            existing.status = eventEntity.status;

        await _context.SaveChangesAsync();
            return existing;
        }

}
