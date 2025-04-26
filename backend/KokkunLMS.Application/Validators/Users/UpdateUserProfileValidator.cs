using FluentValidation;
using KokkunLMS.Application.Commands.Users;

namespace KokkunLMS.Application.Validators.Users;

public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.FullName)
            .MinimumLength(3)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.FullName));

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^[0-9+\-\s()]+$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

        RuleFor(x => x)
            .Must(x =>
                !string.IsNullOrWhiteSpace(x.FullName) ||
                !string.IsNullOrWhiteSpace(x.Email) ||
                !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("At least one field must be provided for update.");
    }
}
