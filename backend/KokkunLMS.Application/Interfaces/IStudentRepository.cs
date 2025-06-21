using System;
using KokkunLMS.Domain.Entities;

namespace KokkunLMS.Application.Interfaces;

public interface IStudentRepository
{
    Task<int> CreateAsync(Student student);
    Task<bool> UpdateAsync(Student student);
    Task<Student?> GetByUserIdAsync(int userId);
    Task<IEnumerable<Student>> GetAllAsync();
}

