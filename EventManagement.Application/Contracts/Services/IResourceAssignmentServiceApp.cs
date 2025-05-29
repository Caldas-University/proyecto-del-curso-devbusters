using EventManagement.Domain.Entities;

namespace EventManagement.Application.Contracts.Services;

    public interface IResourceAssignmentServiceApp
    {
        Task<Guid> ResourceAssignmentAsync(ResourceAssignment assignment);
        Task<ResourceAssignment> GetResourceAssignmentByIdAsync(Guid id);
    }

