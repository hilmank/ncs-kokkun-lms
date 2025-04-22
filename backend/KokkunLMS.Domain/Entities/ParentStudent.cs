namespace KokkunLMS.Domain.Entities
{
    public class ParentStudent
    {
        public int ParentStudentId { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }

        public User? Parent { get; set; }
        public User? Student { get; set; }
    }
}
