using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Repositories;

public interface IResourceAssignmentRepository
{
    Task<Guid> AddResourceAssignmentAsync(ResourceAssignment assignment);
    Task<ResourceAssignment> GetResourceAssignmentByIdAsync(Guid id);
}
