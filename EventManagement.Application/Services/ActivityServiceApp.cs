namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;

public class ActivityServiceApp : IActivityServiceApp
{
    private readonly IActivityRepository _activityRepository;

    public ActivityServiceApp(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
    }

    public async Task<Guid> CreateAsync(Activity activity)
    {
        if (activity == null)
        {
            throw new ArgumentNullException(nameof(activity));
        }

        // ⛔ Validar solapamientos
        var actividadesEnElLugar = await _activityRepository.GetByLocationAndDateAsync(activity.location, activity.date);

        var horaInicioNueva = activity.date;
        var horaFinNueva = horaInicioNueva.AddMinutes(activity.duration);

        var conflicto = actividadesEnElLugar.Any(existing =>
        {
            var inicioExistente = existing.date;
            var finExistente = inicioExistente.AddMinutes(existing.duration);

            return horaInicioNueva < finExistente && horaFinNueva > inicioExistente;
        });

        if (conflicto)
        {
            throw new InvalidOperationException("Ya existe una actividad en ese lugar que se solapa con el horario indicado.");
        }

        var createdActivityId = await _activityRepository.AddAsync(activity);
        return createdActivityId;
    }


    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid activity ID", nameof(id));
        }

        var activity = await _activityRepository.GetByIdAsync(id);
        if (activity == null)
        {
            throw new KeyNotFoundException($"Activity with ID {id} not found");
        }

        return activity;
    }


    public async Task<IEnumerable<Activity>> GetByEventIdAsync(Guid eventId)
    {
        return await _activityRepository.GetByEventIdAsync(eventId);
    }

    public async Task UpdateAsync(Guid id, UpdateRequestActivityDTO dto)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ID inválido");

        var existing = await _activityRepository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"Actividad con ID {id} no encontrada.");

        // Validar solapamiento
        var otrasActividades = await _activityRepository.GetByLocationAndDateAsync(dto.location, dto.date);
        var horaInicioNueva = dto.date;
        var horaFinNueva = dto.date.AddMinutes(dto.duration);

        var conflicto = otrasActividades.Any(a =>
            a.id != id && // excluye la actividad actual
            horaInicioNueva < a.date.AddMinutes(a.duration) &&
            horaFinNueva > a.date
        );

        if (conflicto)
            throw new InvalidOperationException("La nueva hora/ubicación se solapa con otra actividad.");

        // Crear nueva instancia con los cambios
        var actualizada = new Activity(
            id,
            dto.type,
            dto.name,
            dto.date,
            dto.duration,
            dto.description,
            dto.location,
            existing.eventId // preserva el vínculo al evento
        );

        await _activityRepository.UpdateAsync(actualizada);
    }


}
