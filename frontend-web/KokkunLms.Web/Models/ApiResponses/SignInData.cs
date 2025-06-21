using System;

namespace KokkunLms.Web.Models.ApiResponses;

public class SignInData
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public int RefreshTokenExpiryMinutes { get; set; }
}
