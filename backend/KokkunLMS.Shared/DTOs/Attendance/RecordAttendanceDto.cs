namespace KokkunLMS.Shared.DTOs.Attendance;

public class RecordAttendanceDto
{
    public int ScheduleId { get; set; }
    public int StudentId { get; set; }
    public string Date { get; set; } = null!; // ISO 8601 format (yyyy-MM-dd)
    public string Status { get; set; } = null!; // e.g., "Present", "Absent"
    public int? CheckedBy { get; set; }
}
