namespace EventManagement.Application.Mappers;

using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;
using AutoMapper;
    
public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<CreateRequestActivityDTO, Activity>()
            .ConstructUsing(dto => new Activity(
                Guid.NewGuid(),
                dto.type,
                dto.name,
                dto.date,
                dto.duration,
                dto.description,
                dto.location
            ));

        CreateMap<Activity, CreateResponseActivityDTO>();
    }
}
