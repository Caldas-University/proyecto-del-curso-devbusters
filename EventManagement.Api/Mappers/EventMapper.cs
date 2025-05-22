namespace EventManagement.Application.Mappers;

using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;
using AutoMapper;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<CreateRequestEventDTO, Event>();
        CreateMap<Event, CreateResponseEventDTO>();
    }
}