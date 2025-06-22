
using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog log);
    }
}
