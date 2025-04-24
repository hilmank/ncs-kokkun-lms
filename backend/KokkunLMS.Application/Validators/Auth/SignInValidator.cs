using FluentValidation;
using KokkunLMS.Application.Commands.Auth;

namespace KokkunLMS.Application.Validators.Auth;

public class SignInValidator : AbstractValidator<SignInCommand>
{
    public SignInValidator()
    {
        RuleFor(x => x.UsernameOrEmail).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
