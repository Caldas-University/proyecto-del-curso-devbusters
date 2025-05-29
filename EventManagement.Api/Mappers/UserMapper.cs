namespace EventManagement.Application.Mappers;

using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;
using AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>();
    }
}