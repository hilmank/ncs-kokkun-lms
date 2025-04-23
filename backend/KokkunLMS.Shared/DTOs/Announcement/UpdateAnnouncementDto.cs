using System;

namespace KokkunLMS.Shared.DTOs.Announcement;
public class UpdateAnnouncementDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
