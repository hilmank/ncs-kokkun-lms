using FluentValidation;
using KokkunLMS.Application.Features.Auth.Commands;

namespace KokkunLMS.Application.Features.Auth.Validators;

public class SignInValidator : AbstractValidator<SignInCommand>
{
    public SignInValidator()
    {
        RuleFor(x => x.UsernameOrEmail).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
