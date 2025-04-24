using KokkunLMS.Application.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FluentValidation;
using KokkunLMS.Shared.DTOs;

namespace KokkunLMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("signin")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<string>), 200)]
    [ProducesResponseType(typeof(ApiErrorResponse), 400)]
    [ProducesResponseType(typeof(ApiErrorResponse), 401)]
    public async Task<IActionResult> SignInUser([FromBody] SignInCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(ApiResponse<string>.Ok(token, "Signed in successfully."));
    }


    [HttpPost("signout")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<string>), 200)]
    [ProducesResponseType(typeof(ApiErrorResponse), 401)]
    public async Task<IActionResult> SignOutUser()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _mediator.Send(new SignOutCommand(userId));

        return result
            ? Ok(ApiResponse<string>.WithMessage("Signed out successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Sign out failed." });
    }

}
