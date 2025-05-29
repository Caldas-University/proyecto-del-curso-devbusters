namespace EventManagement.Api.Mappers;

using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

public class RolePermissionProfile : Profile
{
    public RolePermissionProfile()
    {
        CreateMap<RolePermissionRequestDTO, RolePermission>();

        CreateMap<RolePermission, RolePermissionResponseDTO>();
    }
}