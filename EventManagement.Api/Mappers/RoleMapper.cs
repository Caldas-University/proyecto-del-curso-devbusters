namespace EventManagement.Api.Mappers;

using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<CreateRequestRoleDTO, Role>();

        CreateMap<Role, CreateResponseRoleDTO>();
    }
}