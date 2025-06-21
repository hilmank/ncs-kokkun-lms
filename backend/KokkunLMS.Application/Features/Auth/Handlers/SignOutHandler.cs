using KokkunLMS.Application.Features.Auth.Commands;
using MediatR;

namespace KokkunLMS.Application.Features.Auth.Handlers;

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
