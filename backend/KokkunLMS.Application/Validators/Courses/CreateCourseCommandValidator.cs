using FluentValidation;
using KokkunLMS.Application.Commands.Courses;

namespace KokkunLMS.Application.Validators.Courses
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.PaketLevel)
                .NotEmpty()
                .Must(level => level == "Paket A" || level == "Paket B" || level == "Paket C")
                .WithMessage("PaketLevel must be 'Paket A', 'Paket B', or 'Paket C'.");

            RuleFor(x => x.GradeLevel)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Subject)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.TeacherId)
                .GreaterThan(0);
        }
    }
}
