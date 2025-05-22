using EventManagement.Domain.Entities;

namespace EventManagement.Application.Contracts.Services;

public interface IEventServiceApp
{
    Task<Guid> EventAsync(Event eventEntity);
    Task<Event> GetEventByIdAsync(Guid id);
}
