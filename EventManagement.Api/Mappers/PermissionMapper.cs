namespace EventManagement.Application.Mappers;

using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;
using AutoMapper;

public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<CreateRequestPermissionDTO, Permission>();
        CreateMap<Permission, CreateResponsePermissionDTO>();
    }
}