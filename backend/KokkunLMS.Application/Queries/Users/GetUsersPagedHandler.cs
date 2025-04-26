using AutoMapper;
using KokkunLMS.Application.Interfaces;
using KokkunLMS.Shared.DTOs;
using KokkunLMS.Shared.DTOs.Users;
using MediatR;

namespace KokkunLMS.Application.Queries.Users;

public class GetUsersPagedHandler : IRequestHandler<GetUsersPagedQuery, PagedResult<UserDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUsersPagedHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<PagedResult<UserDto>> Handle(GetUsersPagedQuery request, CancellationToken cancellationToken)
    {
        var users = await _uow.Users.GetAllAsync();

        // Filtering
        if (request.IsActive.HasValue)
            users = users.Where(x => x.IsActive == request.IsActive.Value);

        if (request.RoleId.HasValue)
            users = users.Where(x => x.RoleId == request.RoleId.Value);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var keyword = request.SearchTerm.Trim().ToLower();
            users = users.Where(x =>
                x.FullName.ToLower().Contains(keyword) ||
                x.Email.ToLower().Contains(keyword) ||
                x.Username.ToLower().Contains(keyword));
        }

        var totalCount = users.Count();

        var pagedUsers = users
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<UserDto>
        {
            Items = _mapper.Map<IEnumerable<UserDto>>(pagedUsers),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
