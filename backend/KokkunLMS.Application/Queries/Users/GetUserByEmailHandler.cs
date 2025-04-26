using AutoMapper;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUserByEmailHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.GetByUsernameOrEmailAsync(request.Email);

        if (user is null)
            throw new NotFoundException("User not found by email.");

        return _mapper.Map<UserDto>(user);
    }
}
