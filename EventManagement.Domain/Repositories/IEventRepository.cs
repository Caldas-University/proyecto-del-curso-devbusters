namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IEventRepository
{
    Task<Guid> AddEventAsync(Event eventEntity);
    Task<Event> GetEventByIdAsync(Guid id);
}
