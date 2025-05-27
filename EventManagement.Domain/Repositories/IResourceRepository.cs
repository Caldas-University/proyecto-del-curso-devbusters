namespace EventManagement.Domain.Repositories;

using EventManagement.Domain.Entities;

public interface IResourceRepository
{
    Task <Guid> AddResourceAsync(Resource resourceEntity);
    Task<Resource> GetResourceByIdAsync(Guid id);
}
