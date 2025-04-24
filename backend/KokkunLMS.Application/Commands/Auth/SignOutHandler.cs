using KokkunLMS.Application.Commands.Auth;
using MediatR;

namespace KokkunLMS.Application.Commands.Auth;

public class SignOutHandler : IRequestHandler<SignOutCommand, bool>
{
    // If you're using token/session tracking, inject a session repo here
    public SignOutHandler() { }

    public Task<bool> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        // TODO: remove token from DB/cache/etc

        // If stateless JWT with no tracking, just return true
        return Task.FromResult(true);
    }
}
