using EventManagement.Application.Contracts.Services;
using EventManagement.Domain.Entities;
using EventManagement.Application.DTO;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

namespace EventManagement.Infrastructure.Repositories;

public class EventReportRepository : IEventReportService
{
    private readonly EventManagementDbContext _context;

    public EventReportRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddReportAsync(EventReport entity)
    {
        entity.Id = Guid.NewGuid();
        _context.EventReports.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EventReport>> GetReportsAsync(Guid? Id, string? activityType, DateTime? startDate, DateTime? endDate)
    {
        var query = _context.EventReports.AsQueryable();

        if (Id.HasValue)
            query = query.Where(r => r.Id == Id.Value);

        if (!string.IsNullOrEmpty(activityType))
            query = query.Where(r => r.ActivityType == activityType);

        if (startDate.HasValue)
            query = query.Where(r => r.Timestamp >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(r => r.Timestamp <= endDate.Value);

        return await query.ToListAsync();
    }

    public async Task<ReportSummaryDto> GetReportSummaryAsync(Guid? Id, string? activityType, DateTime? startDate, DateTime? endDate)
    {
        var query = _context.EventReports.AsQueryable();

        if (Id.HasValue)
            query = query.Where(r => r.Id == Id.Value);

        if (!string.IsNullOrEmpty(activityType))
            query = query.Where(r => r.ActivityType == activityType);

        if (startDate.HasValue)
            query = query.Where(r => r.Timestamp >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(r => r.Timestamp <= endDate.Value);

        var total = await query.CountAsync();

        if (total == 0)
        {
            return new ReportSummaryDto
            {
                TotalReports = 0,
                AverageAttendance = 0,
                AverageOccupancy = 0,
                AverageScheduleCompliance = 0
            };
        }

        return new ReportSummaryDto
        {
            TotalReports = total,
            AverageAttendance = await query.AverageAsync(r => r.AttendanceCount),
            AverageOccupancy = await query.AverageAsync(r => r.OccupancyRate),
            AverageScheduleCompliance = await query.AverageAsync(r => r.ScheduleCompliance)
        };
    }
}