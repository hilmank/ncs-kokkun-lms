namespace KokkunLMS.Shared.DTOs.PerformanceReport;

public class CreatePerformanceReportDto
{
    public int StudentId { get; set; }
    public string Period { get; set; } = null!; // e.g., "Q1-2025"
    public float AverageGrade { get; set; }
    public float AttendanceRate { get; set; }
    public float ParticipationScore { get; set; }
}
