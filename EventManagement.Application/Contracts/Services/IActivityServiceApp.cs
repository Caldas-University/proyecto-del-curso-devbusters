using EventManagement.Domain.Entities;

namespace EventManagement.Application.Contracts.Services;

public interface IActivityServiceApp
{
    Task<Guid> CreateAsync(Activity activity);
    Task<Activity?> GetByIdAsync(Guid id);
}
