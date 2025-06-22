namespace KokkunLMS.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? RoleId { get; }
    }
}