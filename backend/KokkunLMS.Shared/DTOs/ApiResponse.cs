namespace KokkunLMS.Shared.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static ApiResponse<T> Ok(T data, string? message = null) => new()
    {
        Success = true,
        Message = message,
        Data = data
    };

    public static ApiResponse<T> WithMessage(string message) => new()
    {
        Success = true,
        Message = message
    };
}
