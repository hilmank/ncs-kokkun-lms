using FluentValidation;
using KokkunLMS.Application.Features.Users.Commands;

namespace KokkunLMS.Application.Features.Users.Validators;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
    }
}
