namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class EventServiceApp : IEventServiceApp
{
    private readonly IEventRepository _eventRepository;

    public EventServiceApp(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
    }

    public async Task<Guid> EventAsync(Event eventEntity)
    {
        if (eventEntity == null)
        {
            throw new ArgumentNullException(nameof(eventEntity));
        }

        // Validar solapamiento de fechas
        bool conflict = await _eventRepository.ExistsConflictingEventAsync(eventEntity.startDate, eventEntity.endDate);
        if (conflict)
        {
            throw new InvalidOperationException("Las fechas del evento se solapan con otro evento existente.");
        }

        var createdEventId = await _eventRepository.AddEventAsync(eventEntity);
        return createdEventId;
    }

    public async Task<Event> GetEventByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid event ID", nameof(id));
        }

        var eventEntity = await _eventRepository.GetEventByIdAsync(id);
        if (eventEntity == null)
        {
            throw new KeyNotFoundException($"Event with ID {id} not found");
        }

        return eventEntity;
    }
}
