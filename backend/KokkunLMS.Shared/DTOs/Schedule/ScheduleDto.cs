namespace KokkunLMS.Shared.DTOs.Schedule;

public class ScheduleDto
{
    public int ScheduleId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional
    public string DayOfWeek { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public string? VirtualClassLink { get; set; }
}
