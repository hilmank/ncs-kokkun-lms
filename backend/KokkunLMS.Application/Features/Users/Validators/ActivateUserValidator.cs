using FluentValidation;
using KokkunLMS.Application.Features.Users.Commands;

namespace KokkunLMS.Application.Features.Users.Validators;

public class ActivateUserValidator : AbstractValidator<ActivateUserCommand>
{
    public ActivateUserValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
