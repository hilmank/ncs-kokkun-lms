namespace KokkunLMS.Domain.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public required string Status { get; set; }
        public int? CheckedBy { get; set; }

        public Schedule? Schedule { get; set; }
        public User? Student { get; set; }
        public User? CheckedByUser { get; set; }
    }
}
