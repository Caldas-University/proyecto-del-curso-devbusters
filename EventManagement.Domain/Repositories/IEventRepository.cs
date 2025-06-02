namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IEventRepository
{
    Task<Guid> AddEventAsync(Event eventEntity);
    Task<Event> GetEventByIdAsync(Guid id);
    Task<bool> ExistsConflictingEventAsync(DateTime startDate, DateTime endDate, Guid? excludeEventId = null);
    Task<Event> ModifyEventAsync(Event eventEntity);
}
