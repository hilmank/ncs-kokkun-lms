namespace KokkunLMS.Domain.Entities
{
    public class CourseClass
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int CourseId { get; set; }

        // Optional navigation property
        public Course? Course { get; set; }
    }
}
