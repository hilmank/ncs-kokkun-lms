using FluentValidation;
using KokkunLMS.Application.Features.Users.Commands;

namespace KokkunLMS.Application.Features.Users.Validators;

public class DeactivateUserValidator : AbstractValidator<DeactivateUserCommand>
{
    public DeactivateUserValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
