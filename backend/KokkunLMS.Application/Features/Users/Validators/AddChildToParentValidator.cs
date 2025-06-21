using FluentValidation;
using KokkunLMS.Application.Features.Users.Commands;

namespace KokkunLMS.Application.Features.Users.Validators;

public class AddChildToParentValidator : AbstractValidator<AddChildToParentCommand>
{
    public AddChildToParentValidator()
    {
        RuleFor(x => x.ParentId).GreaterThan(0);
        RuleFor(x => x.StudentUsername).NotEmpty().MinimumLength(4);
        RuleFor(x => x.StudentFullName).NotEmpty();
        RuleFor(x => x.StudentEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.StudentPhoneNumber).NotEmpty();
    }
}
