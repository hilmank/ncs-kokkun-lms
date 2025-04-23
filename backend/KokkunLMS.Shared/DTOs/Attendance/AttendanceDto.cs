namespace KokkunLMS.Shared.DTOs.Attendance;

public class AttendanceDto
{
    public int AttendanceId { get; set; }
    public int ScheduleId { get; set; }
    public string DayOfWeek { get; set; } = null!; // Optional enrichment
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!; // Optional enrichment
    public string Date { get; set; } = null!; // yyyy-MM-dd
    public string Status { get; set; } = null!;
    public int? CheckedBy { get; set; }
    public string? CheckedByName { get; set; } // Optional enrichment
}
