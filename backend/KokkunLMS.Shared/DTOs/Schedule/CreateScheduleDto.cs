namespace KokkunLMS.Shared.DTOs.Schedule;

public class CreateScheduleDto
{
    public int CourseId { get; set; }
    public string DayOfWeek { get; set; } = null!; // e.g., "Monday"
    public string StartTime { get; set; } = null!; // format: HH:mm:ss
    public string EndTime { get; set; } = null!;
    public string? VirtualClassLink { get; set; }
}
