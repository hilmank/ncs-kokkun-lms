using KokkunLMS.Application.Commands.Courses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KokkunLMS.Shared.DTOs;

namespace KokkunLMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "teacher, administrator")] // Only Teachers or Admins can create a course
        [ProducesResponseType(typeof(ApiResponse<int>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var courseId = await _mediator.Send(command);
            return Ok(ApiResponse<int>.Ok(courseId, "Course created successfully."));
        }
    }
}
