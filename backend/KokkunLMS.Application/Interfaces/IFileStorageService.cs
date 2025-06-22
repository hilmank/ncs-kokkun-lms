using Microsoft.AspNetCore.Http;

namespace KokkunLMS.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string folder, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string fileName, string folder, CancellationToken cancellationToken = default);

}
