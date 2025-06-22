using AutoMapper;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Queries;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUserByUsernameHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.GetByUsernameOrEmailAsync(request.Username);

        if (user is null)
            throw new NotFoundException("User not found by username.");

        return _mapper.Map<UserDto>(user);
    }
}
