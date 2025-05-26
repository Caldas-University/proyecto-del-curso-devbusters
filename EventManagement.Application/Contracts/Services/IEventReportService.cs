using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;

namespace EventManagement.Application.Contracts.Services;

public interface IEventReportService
{
    Task AddReportAsync(EventReport report);
    Task<IEnumerable<EventReport>> GetReportsAsync(string? eventId, string? activityType, DateTime? startDate, DateTime? endDate);
    Task<ReportSummaryDto> GetReportSummaryAsync(string? eventId, string? activityType, DateTime? startDate, DateTime? endDate);
}