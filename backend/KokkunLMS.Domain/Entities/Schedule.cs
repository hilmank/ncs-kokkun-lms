namespace KokkunLMS.Domain.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int CourseId { get; set; }
        public required string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? VirtualClassLink { get; set; }

        public Course? Course { get; set; }
        public List<Attendance>? Attendances { get; set; }
    }
}
