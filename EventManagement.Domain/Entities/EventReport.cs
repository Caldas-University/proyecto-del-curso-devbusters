namespace EventManagement.Domain.Entities;

public class EventReport
{
    public Guid Id { get; set; }
    public string ActivityType { get; set; } = null!;
    public int RegisteredCount { get; set; }
    public int AttendanceCount { get; set; }
    public double OccupancyRate { get; set; }
    public string ResourceUsage { get; set; } = null!;
    public double ScheduleCompliance { get; set; }
    public DateTime Timestamp { get; set; }
}