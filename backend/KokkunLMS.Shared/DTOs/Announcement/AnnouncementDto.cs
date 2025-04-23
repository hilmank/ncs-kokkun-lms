using System;

namespace KokkunLMS.Shared.DTOs.Announcement;

public class AnnouncementDto
{
    public int AnnouncementId { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = null!; // Optional, for enriched view
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int PostedBy { get; set; }
    public string PostedByName { get; set; } = null!; // Optional, for enriched view
    public string PostedAt { get; set; } = null!;
}
