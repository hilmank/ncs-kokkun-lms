namespace KokkunLMS.Shared.DTOs;

public class ApiErrorResponse
{
    public string Error { get; set; } = "An error occurred.";
    public List<ApiErrorDetail>? Details { get; set; }
}

public class ApiErrorDetail
{
    public string? Field { get; set; }
    public string Message { get; set; } = null!;
}
