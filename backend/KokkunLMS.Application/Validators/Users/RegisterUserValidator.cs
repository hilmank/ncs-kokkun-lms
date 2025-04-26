using FluentValidation;
using KokkunLMS.Application.Commands.Users;

namespace KokkunLMS.Application.Validators.Users;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        // Parent
        RuleFor(x => x.ParentUsername).NotEmpty().MinimumLength(4);
        RuleFor(x => x.ParentFullName).NotEmpty();
        RuleFor(x => x.ParentEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.ParentPhoneNumber).NotEmpty();
        RuleFor(x => x.ParentPassword).NotEmpty().MinimumLength(6);
        RuleFor(x => x.ParentConfirmPassword)
            .Equal(x => x.ParentPassword).WithMessage("Passwords do not match.");

        // Student
        RuleFor(x => x.StudentUsername).NotEmpty().MinimumLength(4);
        RuleFor(x => x.StudentFullName).NotEmpty();
        RuleFor(x => x.StudentEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.StudentPhoneNumber).NotEmpty();
    }
}
