namespace KokkunLMS.Shared.DTOs.Schedule;

public class UpdateScheduleDto
{
    public string DayOfWeek { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public string? VirtualClassLink { get; set; }
}
