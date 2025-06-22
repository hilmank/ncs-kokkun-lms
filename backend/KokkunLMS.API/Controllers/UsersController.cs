using System.Security.Claims;
using KokkunLMS.Application.Features.Users.Commands;
using KokkunLMS.Application.Features.Users.Queries;
using KokkunLMS.Shared.DTOs;
using KokkunLMS.Shared.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KokkunLMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a new user (Admin only).
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "administrator")]
    [ProducesResponseType(typeof(ApiResponse<int>), 200)]
    [ProducesResponseType(typeof(ApiErrorResponse), 400)]
    [ProducesResponseType(typeof(ApiErrorResponse), 409)]
    public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(ApiResponse<int>.Ok(userId, "User created successfully."));
    }

    /// <summary>
    /// Update a user's details (Admin only).
    /// </summary>
    [HttpPut("{userId}")]
    [Authorize(Roles = "administrator")]
    [ProducesResponseType(typeof(ApiResponse<string>), 200)]
    [ProducesResponseType(typeof(ApiErrorResponse), 400)]
    public async Task<IActionResult> UpdateUser(int userId, [FromForm] UpdateUserCommand command)
    {
        command.UserId = userId;
        var updated = await _mediator.Send(command);
        return updated
            ? Ok(ApiResponse<string>.WithMessage("User updated successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Failed to update user." });
    }

    /// <summary>
    /// Update logged-in user's profile.
    /// </summary>
    [HttpPut("profile")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<string>), 200)]
    [ProducesResponseType(typeof(ApiErrorResponse), 400)]
    public async Task<IActionResult> UpdateProfile([FromForm] UpdateUserProfileCommand command)
    {
        var updated = await _mediator.Send(command);
        return updated
            ? Ok(ApiResponse<string>.WithMessage("Profile updated successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Update failed." });
    }
    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var success = await _mediator.Send(command);
        return success
            ? Ok(ApiResponse<string>.WithMessage("Password changed successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Password change failed." });
    }
    [HttpPost("{userId}/activate")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> ActivateUser(int userId)
    {
        var command = new ActivateUserCommand(userId);
        var result = await _mediator.Send(command);

        return result
            ? Ok(ApiResponse<string>.WithMessage("User activated successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Activation failed." });
    }
    [HttpPost("{userId}/deactivate")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> DeactivateUser(int userId)
    {
        var command = new DeactivateUserCommand(userId);
        var result = await _mediator.Send(command);

        return result
            ? Ok(ApiResponse<string>.WithMessage("User deactivated successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Deactivation failed." });
    }
    [HttpDelete("{userId}")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var command = new DeleteUserCommand(userId);
        var result = await _mediator.Send(command);

        return result
            ? Ok(ApiResponse<string>.WithMessage("User deleted successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Delete failed." });
    }
    [HttpPost("{userId}/reset-password")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> ResetPassword(int userId, [FromBody] string newPassword)
    {
        var command = new ResetPasswordCommand(userId, newPassword);
        var result = await _mediator.Send(command);

        return result
            ? Ok(ApiResponse<string>.WithMessage("Password reset successfully."))
            : BadRequest(new ApiErrorResponse { Error = "Password reset failed." });
    }


    [HttpGet]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUsers([FromQuery] bool? isActive, [FromQuery] bool? isDeleted, [FromQuery] int? roleId)
    {
        var query = new GetUsersQuery(isActive, isDeleted, roleId);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<IEnumerable<UserDto>>.Ok(result));
    }
    [HttpGet("{userId}")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var query = new GetUserByIdQuery(userId);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<UserDto>.Ok(result));
    }
    [HttpGet("by-email")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var query = new GetUserByEmailQuery(email);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<UserDto>.Ok(result));
    }

    [HttpGet("paged")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUsersPaged(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] int? roleId = null,
        [FromQuery] bool? isActive = null)
    {
        var query = new GetUsersPagedQuery(page, pageSize, searchTerm, roleId, isActive);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<PagedResult<UserDto>>.Ok(result));
    }
    [HttpGet("by-username")]
    [Authorize(Roles = "administrator")]
    public async Task<IActionResult> GetUserByUsername([FromQuery] string username)
    {
        var query = new GetUserByUsernameQuery(username);
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<UserDto>.Ok(result));
    }

}
