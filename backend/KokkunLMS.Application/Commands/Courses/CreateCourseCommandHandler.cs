using KokkunLMS.Application.Commands.Courses;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Domain.Entities;
using FluentValidation;
using MediatR;

namespace KokkunLMS.Application.Handlers.Courses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IValidator<CreateCourseCommand> _validator;

        public CreateCourseCommandHandler(
            ICourseRepository courseRepository,
            IValidator<CreateCourseCommand> validator)
        {
            _courseRepository = courseRepository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var course = new Course
            {
                Title = request.Title,
                PaketLevel = request.PaketLevel,
                GradeLevel = request.GradeLevel,
                Subject = request.Subject,
                TeacherId = request.TeacherId,
                CreatedAt = DateTime.UtcNow
            };

            await _courseRepository.CreateAsync(course);

            return course.CourseId;
        }
    }
}
