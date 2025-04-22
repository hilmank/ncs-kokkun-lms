namespace KokkunLMS.Domain.Entities
{
    public class PerformanceReport
    {
        public int ReportId { get; set; }
        public int StudentId { get; set; }
        public required string Period { get; set; }
        public decimal? AverageGrade { get; set; }
        public decimal? AttendanceRate { get; set; }
        public decimal? ParticipationScore { get; set; }
        public DateTime GeneratedAt { get; set; }

        public User? Student { get; set; }
    }
}
