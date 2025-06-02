using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;

namespace EventManagement.Application.Contracts.Services;

public interface IEventReportService
{
    Task AddReportAsync(EventReport report);
    Task<IEnumerable<EventReport>> GetReportsAsync(Guid? Id, string? activityType, DateTime? startDate, DateTime? endDate);
    Task<ReportSummaryDto> GetReportSummaryAsync(Guid? Id, string? activityType, DateTime? startDate, DateTime? endDate);
}