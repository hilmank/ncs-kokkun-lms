using FluentValidation;
using KokkunLMS.Application.Features.Users.Commands;

namespace KokkunLMS.Application.Features.Users.Validators;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
