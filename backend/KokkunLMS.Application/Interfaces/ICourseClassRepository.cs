using System;
using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces;

public interface ICourseClassRepository
{
    public interface ICourseClassRepository
    {
        Task<IEnumerable<CourseClass>> GetAllAsync();
        Task<CourseClass?> GetByCodeAsync(string code);
        Task<int> CreateAsync(CourseClass courseClass);
        Task<bool> UpdateAsync(CourseClass courseClass);
    }

}
