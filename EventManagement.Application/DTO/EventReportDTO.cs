namespace EventManagement.Application.DTO;


public class EventReportDto
{
    public string? EventId { get; set; }
    public string? ActivityType { get; set; }
    public int RegisteredCount { get; set; }
    public int AttendanceCount { get; set; }
    public double OccupancyRate { get; set; }
    public string? ResourceUsage { get; set; }
    public double ScheduleCompliance { get; set; }
    public DateTime Timestamp { get; set; }
}
