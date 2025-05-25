namespace EventManagement.Application.DTO;

public class ReportSummaryDto
{
    public int TotalReports { get; set; }
    public double AverageAttendance { get; set; }
    public double AverageOccupancy { get; set; }
    public double AverageScheduleCompliance { get; set; }
}