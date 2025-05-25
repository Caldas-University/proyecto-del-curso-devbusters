using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;
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

    public async Task AddReportAsync(EventReportDto dto)
    {
        var entity = new EventReport
        {
            Id = Guid.NewGuid(),
            EventId = dto.EventId,
            ActivityType = dto.ActivityType,
            RegisteredCount = dto.RegisteredCount,
            AttendanceCount = dto.AttendanceCount,
            OccupancyRate = dto.OccupancyRate,
            ResourceUsage = dto.ResourceUsage,
            ScheduleCompliance = dto.ScheduleCompliance,
            Timestamp = dto.Timestamp
        };

        _context.EventReports.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EventReportDto>> GetReportsAsync(string? eventId, string? activityType, DateTime? startDate, DateTime? endDate)
    {
        var query = _context.EventReports.AsQueryable();

        if (!string.IsNullOrEmpty(eventId))
            query = query.Where(r => r.EventId == eventId);

        if (!string.IsNullOrEmpty(activityType))
            query = query.Where(r => r.ActivityType == activityType);

        if (startDate.HasValue)
            query = query.Where(r => r.Timestamp >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(r => r.Timestamp <= endDate.Value);

        return await query.Select(r => new EventReportDto
        {
            EventId = r.EventId,
            ActivityType = r.ActivityType,
            RegisteredCount = r.RegisteredCount,
            AttendanceCount = r.AttendanceCount,
            OccupancyRate = r.OccupancyRate,
            ResourceUsage = r.ResourceUsage,
            ScheduleCompliance = r.ScheduleCompliance,
            Timestamp = r.Timestamp
        }).ToListAsync();
    }

    public async Task<ReportSummaryDto> GetReportSummaryAsync(
    string? eventId,
    string? activityType,
    DateTime? startDate,
    DateTime? endDate)
    {
        var query = _context.EventReports.AsQueryable();

        if (!string.IsNullOrEmpty(eventId))
            query = query.Where(r => r.EventId == eventId);

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