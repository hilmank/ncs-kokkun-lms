using System;

namespace KokkunLms.Web.Models.ApiResponses;

public class SignInApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public SignInData Data { get; set; } = new SignInData();
}
