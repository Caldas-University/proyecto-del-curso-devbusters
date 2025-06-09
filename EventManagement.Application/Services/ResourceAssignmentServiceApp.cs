namespace EventManagement.Application.Services;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using EventManagement.Application.Contracts.Services;

public class ResourceAssignmentServiceApp : IResourceAssignmentServiceApp
{
    private readonly IResourceAssignmentRepository _assignmentRepository;

    public ResourceAssignmentServiceApp(IResourceAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
    }

    public async Task<Guid> ResourceAssignmentAsync(ResourceAssignment assignment)
    {
        if (assignment == null)
        {
            throw new ArgumentNullException(nameof(assignment));
        }

        var createdAssignmentId = await _assignmentRepository.AddResourceAssignmentAsync(assignment);
        return createdAssignmentId;
    }

    public async Task<ResourceAssignment> GetResourceAssignmentByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid resource assignment ID", nameof(id));
        }

        var assignment = await _assignmentRepository.GetResourceAssignmentByIdAsync(id);
        if (assignment == null)
        {
            throw new KeyNotFoundException($"Resource assignment with ID {id} not found");
        }

        return assignment;
    }
}
