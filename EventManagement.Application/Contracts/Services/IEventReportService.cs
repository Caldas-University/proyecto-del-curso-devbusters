using EventManagement.Application.DTO;

namespace EventManagement.Application.Contracts.Services;

public interface IEventReportService
{
    Task AddReportAsync(EventReportDto report);
    Task<IEnumerable<EventReportDto>> GetReportsAsync(
        string? eventId,
        string? activityType,
        DateTime? startDate,
        DateTime? endDate
    );

    Task<ReportSummaryDto> GetReportSummaryAsync(
    string? eventId,
    string? activityType,
    DateTime? startDate,
    DateTime? endDate
);

}