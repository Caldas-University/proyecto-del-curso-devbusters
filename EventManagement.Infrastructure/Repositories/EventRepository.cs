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

}
