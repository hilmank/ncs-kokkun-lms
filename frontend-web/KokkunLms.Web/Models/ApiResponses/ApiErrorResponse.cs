using System;

namespace KokkunLms.Web.Models.ApiResponses;

public class ApiErrorResponse
{
    public string Error { get; set; } = string.Empty;
    public List<ApiErrorResponseDetails> Details { get; set; } = new List<ApiErrorResponseDetails>();
}
public class ApiErrorResponseDetails
{
    public string Field { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
