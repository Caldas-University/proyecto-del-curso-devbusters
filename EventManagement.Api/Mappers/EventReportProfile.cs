using AutoMapper;
using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;

namespace EventManagement.Api.Mappers
{
    public class EventReportProfile : Profile
    {
        public EventReportProfile()
        {
            CreateMap<EventReport, EventReportDto>().ReverseMap();
            CreateMap<ReportSummaryDto, ReportSummaryDto>();
        }
    }
}