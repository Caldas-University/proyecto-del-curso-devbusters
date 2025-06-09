using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

namespace EventManagement.Application.Contracts.Services;

public interface IActivityServiceApp
{
    Task<Guid> CreateAsync(Activity activity);
    Task<Activity?> GetByIdAsync(Guid id);
    Task<IEnumerable<Activity>> GetByEventIdAsync(Guid eventId);
    Task UpdateAsync(Guid id, UpdateRequestActivityDTO dto);

}
