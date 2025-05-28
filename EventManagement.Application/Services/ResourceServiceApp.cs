namespace EventManagement.Application.Services;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using EventManagement.Application.Contracts.Services;


public class ResourceServiceApp : IResourceServiceApp

{
    private readonly IResourceRepository _resourceRepository;
    public ResourceServiceApp(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
    }

    public async Task<Guid> ResourceAsync(Resource resourceEntity)
    {
        if (resourceEntity == null)
        {
            throw new ArgumentNullException(nameof(resourceEntity));
        }
        var createdResourceId = await _resourceRepository.AddResourceAsync(resourceEntity);
        return createdResourceId;
    }

    public async Task<Resource> GetResourceByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid resource ID", nameof(id));
        }

        var resourceEntity = await _resourceRepository.GetResourceByIdAsync(id);
        if (resourceEntity == null)
        {
            throw new KeyNotFoundException($"Resource with ID {id} not found");
        }

        return resourceEntity;
    }
}

