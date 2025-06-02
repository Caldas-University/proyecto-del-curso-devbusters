namespace EventManagement.Application.Mappers;

using AutoMapper;
using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;

public class ResourceAssignmentProfile : Profile
{
    public ResourceAssignmentProfile()
    {
        CreateMap<CreateRequestResourceAssignmentDTO, ResourceAssignment>()
            .ConstructUsing(dto => new ResourceAssignment(
                Guid.NewGuid(),
                dto.activityId,
                dto.resourceId,
                dto.quantity,
                dto.assignedFrom,
                dto.assignedTo
            ));

        CreateMap<ResourceAssignment, CreateResponseResourceAssignmentDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.activityId, opt => opt.MapFrom(src => src.idActivity))
            .ForMember(dest => dest.resourceId, opt => opt.MapFrom(src => src.idResource))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.quantity))
            .ForMember(dest => dest.assignedFrom, opt => opt.MapFrom(src => src.assignedFrom))
            .ForMember(dest => dest.assignedTo, opt => opt.MapFrom(src => src.assignedTo));
    }
}
