using AutoMapper;
using KokkunLMS.Application.Features.Users.Queries;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUsersHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _uow.Users.GetAllAsync();

        // Filtering
        if (request.IsActive.HasValue)
            users = users.Where(x => x.IsActive == request.IsActive.Value);

        if (request.IsDeleted.HasValue)
            users = users.Where(x => x.IsDeleted == request.IsDeleted.Value);

        if (request.RoleId.HasValue)
            users = users.Where(x => x.RoleId == request.RoleId.Value);

        // ✅ Use AutoMapper here
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}
