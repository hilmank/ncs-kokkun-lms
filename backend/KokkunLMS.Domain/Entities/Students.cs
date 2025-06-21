namespace KokkunLMS.Domain.Entities
{
    public class Student
    {
        public int UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderCode { get; set; } = null!;
        public DateTime RegistrationDat { get; set; }
        public DateTime? EnrollmentDat { get; set; }
        public string ClassCode { get; set; } = null!;
        public int Status { get; set; }

        // Navigation properties
        public User? User { get; set; }          // FK to users
        public Gender? Gender { get; set; }      // FK to genders
        public CourseClass? CourseClass { get; set; }  // FK to courseclass
    }
}
