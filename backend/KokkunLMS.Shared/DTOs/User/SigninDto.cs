using System;

namespace KokkunLMS.Shared.DTOs.User;

public class SigninDto
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public double RefreshTokenExpiryMinutes { get; set; }
}
