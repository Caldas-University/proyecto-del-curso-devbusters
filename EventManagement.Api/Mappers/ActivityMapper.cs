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
                dto.location,
                dto.eventId
            ));

        CreateMap<Activity, CreateResponseActivityDTO>();

        CreateMap<UpdateRequestActivityDTO, Activity>()
    .ConstructUsing((dto, ctx) =>
        new Activity(Guid.Empty, dto.type, dto.name, dto.date, dto.duration, dto.description, dto.location, Guid.Empty));

    }
}
