using System;
using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces;

public interface IGenderRepository
{
    Task<IEnumerable<Gender>> GetAllAsync();
    Task<Gender?> GetByCodeAsync(string code);
}
