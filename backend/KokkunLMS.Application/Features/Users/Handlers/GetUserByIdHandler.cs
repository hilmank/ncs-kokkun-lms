using AutoMapper;
using KokkunLMS.Application.Exceptions;
using KokkunLMS.Application.Features.Users.Queries;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.User;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.GetByIdAsync(request.UserId);

        if (user is null)
            throw new NotFoundException("User not found.");

        return _mapper.Map<UserDto>(user);
    }
}
