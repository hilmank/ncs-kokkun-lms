namespace KokkunLMS.Shared.DTOs.DiscussionThread;

public class CreateDiscussionThreadDto
{
    public int CourseId { get; set; }
    public int CreatedBy { get; set; }
    public string Title { get; set; } = null!;
}
