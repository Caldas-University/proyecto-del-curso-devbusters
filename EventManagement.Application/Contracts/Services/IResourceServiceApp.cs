using EventManagement.Domain.Entities;

namespace EventManagement.Application.Contracts.Services;

public interface IResourceServiceApp
{
    Task<Guid> ResourceAsync(Resource resource);
    Task<Resource> GetResourceByIdAsync(Guid id);
}

