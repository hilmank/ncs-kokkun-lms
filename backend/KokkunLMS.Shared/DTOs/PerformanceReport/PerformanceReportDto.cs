namespace KokkunLMS.Shared.DTOs.PerformanceReport;

public class PerformanceReportDto
{
    public int ReportId { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!; // Optional
    public string Period { get; set; } = null!;
    public float AverageGrade { get; set; }
    public float AttendanceRate { get; set; }
    public float ParticipationScore { get; set; }
    public string GeneratedAt { get; set; } = null!;
}
