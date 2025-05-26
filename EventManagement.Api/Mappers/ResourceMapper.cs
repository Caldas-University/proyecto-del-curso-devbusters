namespace EventManagement.Api.Mappers;

using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;


public class ResourceProfile : Profile
{
    public ResourceProfile()
    {
        // De DTO → Entidad
        CreateMap<CreateRequestResourceDTO, Resource>();

        // De Entidad → DTO de respuesta
        CreateMap<Resource, CreateResponseResourceDTO>();
    }
}

