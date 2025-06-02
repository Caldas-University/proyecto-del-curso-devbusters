namespace EventManagement.Api.Mappers;

using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

public class RoleUserProfile : Profile
{
    public RoleUserProfile()
    {
        CreateMap<RoleUserRequestDTO, RoleUser>();
        CreateMap<RoleUser, RoleUserResponseDTO>();
    }
}