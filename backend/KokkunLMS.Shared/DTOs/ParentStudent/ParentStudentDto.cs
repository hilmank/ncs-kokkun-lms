namespace KokkunLMS.Shared.DTOs.ParentStudent;

public class ParentStudentDto
{
    public int ParentStudentId { get; set; }
    public int ParentId { get; set; }
    public string ParentName { get; set; } = null!; // Optional
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!; // Optional
}
