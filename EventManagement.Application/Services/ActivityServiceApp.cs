namespace EventManagement.Application.Services;

using EventManagement.Application.Contracts.Services;
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
}
