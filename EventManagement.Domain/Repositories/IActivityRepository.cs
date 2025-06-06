namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IActivityRepository
{
    Task<Guid> AddAsync(Activity activity);
    Task<Activity?> GetByIdAsync(Guid id);
}
